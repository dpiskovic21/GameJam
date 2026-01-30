using WinFormsApp1.enums;
using WinFormsApp1.models;

namespace WinFormsApp1.Game
{
    public static class GameState
    {
        #region global info (immutable)

        public const int EnergyAvailableEachTurn = 5;
        public const int MaxAltarSize = 3;
        public const int MaxDays = 7;
        public const int MaxHandSize = 5;

        #endregion

        #region Global game state

        public static int Day { get; private set; } = 1;
        public static int TotalScore { get; private set; } = 0;
        public static int CurrentBalance { get; private set; } = 0;
        public static bool IsGameOver { get; private set; } = false;

        #endregion


        #region Turn based props

        public static List<Card> Hand { get; set; } = new List<Card>();
        public static List<Card> Altar { get; set; } = new List<Card>();
        public static int AvailableEnergy { get; set; }
        public static int CurrentHandBalance
        {
            get
            {
                return Hand.Select(x =>
                {
                    if (x == null)
                    {
                        return 0;
                    }

                    if ((x.CardTypeEnum == CardTypeEnum.Light && RoundModifier == RoundModifierEnum.LightDoubleValue) || (x.CardTypeEnum == CardTypeEnum.Dark && RoundModifier == RoundModifierEnum.DarkDoubleValue))
                    {
                        return x.Value * 2;
                    }

                    return x.Value;
                }).Sum();
            }
        }
        public static RoundModifierEnum RoundModifier;
        #endregion


        #region Thread and Sync
        private static Queue<int> _scoreMessageQueue = new Queue<int>();
        private static readonly object _syncLock = new object();

        private static Thread _scoreThread;
        private static bool _keepRunning = true;

        public static event Action<int> OnScoreProcessed;

        public static void InitThreading()
        {
            _keepRunning = true;
            _scoreThread = new Thread(ProcessScoreQueue);
            _scoreThread.IsBackground = true;
            _scoreThread.Start();
        }

        private static void ProcessScoreQueue()
        {
            while (_keepRunning)
            {
                int scoreToDisplay = 0;
                bool hasScore = false;

                lock (_syncLock)
                {
                    while (_scoreMessageQueue.Count == 0 && _keepRunning)
                    {
                        Monitor.Wait(_syncLock);
                    }

                    if (!_keepRunning)
                        break;

                    scoreToDisplay = _scoreMessageQueue.Dequeue();
                    hasScore = true;
                }

                if (hasScore)
                {
                    OnScoreProcessed?.Invoke(scoreToDisplay);
                    Thread.Sleep(500);
                }
            }
        }

        public static void StopThreading()
        {
            lock (_syncLock)
            {
                _keepRunning = false;
                Monitor.PulseAll(_syncLock);
            }
        }

        #endregion

        #region Game Control

        //TODO scoring nakon svakog turna za score;
        public static void StartNewGame()
        {
            Day = 1;
            TotalScore = 0;
            CurrentBalance = 0;
            IsGameOver = false;

            Hand.Clear();
            Altar.Clear();

            if (_scoreThread == null || !_scoreThread.IsAlive)
            {
                InitThreading();
            }

            Deck.InitializeDeck();
            StartTurn();
        }

        public static void StartTurn()
        {
            if (Day > MaxDays)
            {
                IsGameOver = true;
                return;
            }

            SetRoundModifier();
            AvailableEnergy = EnergyAvailableEachTurn;
            if (RoundModifier == RoundModifierEnum.EnergyDebuff)
            {
                AvailableEnergy--;
            }
            DrawCards(5, false);
        }

        private static void SetRoundModifier()
        {
            Array values = Enum.GetValues(typeof(RoundModifierEnum));
            Random random = new Random();
            RoundModifier = (RoundModifierEnum)values.GetValue(random.Next(values.Length));
        }

        public static Card? PeekFirstCard()
        {
            if (RoundModifier != RoundModifierEnum.PeekFirstCard)
            {
                return null;
            }

            return Deck.ShuffledDeck.FirstOrDefault();
        }

        public static void DrawCards(int numberOfCardsToDraw, bool isPlayerDraw = true) //ak je isPlayerDraw false znaci da je to RoundStart draw od 5 karti
        {
            if (AvailableEnergy == 0)
            {
                return;
            }
            if (Deck.ShuffledDeck.Count < numberOfCardsToDraw)
            {
                //TODO vidjeti kaj napraviti ak nema dosta karti
                throw new Exception("Not enough cards in the deck.");
            }

            if (Hand.Count == MaxHandSize)
            {
                //neke vratit mozda da buda jasno na UI-u?
                return;
            }

            var newCards = Deck.ShuffledDeck.Take(numberOfCardsToDraw).ToList();

            if (!isPlayerDraw && RoundModifier == RoundModifierEnum.LockedHandCard)
            {
                Random random = new Random();
                var randomIndex = random.NextInt64(0, newCards.Count);
                newCards.ElementAt((int)randomIndex).IsLocked = true;
            }


            Hand.AddRange(newCards);

            foreach (var card in newCards)
            {
                Deck.ShuffledDeck.Remove(card);
            }

            if (isPlayerDraw)
            {
                AvailableEnergy--;
            }

        }

        #endregion

        #region Player Actions

        public static bool MoveHandToAltar(Card card) //Todo zamjeni dynamic s klasom
        {
            //TODO mozda dodati se se salje i tekst u ovisnosti radi cega nemre
            //ili se sam prikze genericki tekst da nemre to npraviti
            if (AvailableEnergy <= 0)
                return false;
            if (Altar.Count >= MaxAltarSize)
                return false;
            if (!Hand.Contains(card))
                return false; // ak slucajne neke sjebeme na fronte

            Hand.Remove(card);
            Altar.Add(card);
            AvailableEnergy--;

            return true;
        }

        public static bool MoveAltarToHand(Card card) //Todo zamjeni dynamic s klasom
        {
            //TODO mozda dodati se se salje i tekst u ovisnosti radi cega nemre
            //ili se sam prikze genericki tekst da nemre to npraviti            
            if (Hand.Count >= MaxHandSize)
                return false;
            if (!Altar.Contains(card))
                return false; // ak se slucajne neke sjebe na fronte
            Altar.Remove(card);
            Hand.Add(card);
            return true;
        }

        public static bool DiscardFromAltar(Card card) //Todo zamjeni dynamic s klasom
        {
            //TODO mozda dodati se se salje i tekst u ovisnosti radi cega nemre
            //ili se sam prikze genericki tekst da nemre to npraviti
            if (AvailableEnergy <= 0)
                return false;
            if (!Altar.Contains(card))
                return false; // ak se slucajne neke sjebe na fronte

            Altar.Remove(card);
            AvailableEnergy--;

            return true;
        }

        #endregion


        #region End Turn Logic

        public static void EndTurn()
        {
            int roundScore = CalculateScoreIternal();

            lock (_syncLock)
            {
                _scoreMessageQueue.Enqueue(roundScore);
                Monitor.Pulse(_syncLock);
            }

            Hand.Clear();
            Day++;

            if (Day > MaxDays)
            {
                IsGameOver = true;
            }
            else
            {
                StartTurn();
            }
        }

        private static int CalculateScoreIternal()
        {
            int sum = Hand.Sum(c => c.Value);
            CurrentBalance += sum;

            int distanceZero = Math.Abs(sum);
            int roundScore = 10 - distanceZero;
            if (roundScore < 0)
                roundScore = 0;

            TotalScore += roundScore;
            return roundScore;
        }

        #endregion

    }
}
