using System.Collections.Concurrent;
using WinFormsApp1.Assets;
using WinFormsApp1.enums;
using WinFormsApp1.models;
using WinFormsApp1.service;

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

        #region Threading

        private static readonly object _scoreLock = new object();
        private static BlockingCollection<int> _scoreQueue = new BlockingCollection<int>();
        private static volatile bool _isRunning = false;

        private static void ProcessScores()
        {
            foreach (var score in _scoreQueue.GetConsumingEnumerable())
            {
                _ = GoogleSheetService.SubmitScore("asdf", score);
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

            if (!_isRunning)
            {
                _isRunning = true;
                _scoreQueue = new BlockingCollection<int>();
                Thread backgroundWorker = new Thread(ProcessScores) { IsBackground = true };
                backgroundWorker.Start();
            }

            Hand.Clear();
            Altar.Clear();

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
                SFX.PlaySfx($"..\\..\\..\\resources\\card_flip.wav",volume: 0.9f);
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

            Hand.Clear();
            Day++;

            if (Day > MaxDays)
            {
                IsGameOver = true;
                _scoreQueue.Add(TotalScore);
                _scoreQueue.CompleteAdding();
                _isRunning = false;

                Hand.Clear();
                Hand.TrimExcess();
                Altar.Clear();
                Altar.TrimExcess();
            }
            else
            {
                StartTurn();
            }
        }

        private static int CalculateScoreIternal()
        {
            int balance = CurrentHandBalance;
            CurrentBalance += balance;

            const int MaxRoundScore = 20;
            const int ScoreMultiplier = 100;

            int roundScore = (MaxRoundScore * ScoreMultiplier) / (1 + Math.Abs(balance));

            if (balance == 0)
                roundScore += ScoreMultiplier;

            TotalScore += roundScore;
            return roundScore;
        }

        #endregion

    }
}
