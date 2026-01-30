using WinFormsApp1.models;

namespace WinFormsApp1.Game
{
    public static class GameState
    {
        #region global info (immutable)

        public const int EnergyAvailableEachTurn = 5;
        public const int MaxAltarSize = 3;
        public const int MaxDays = 7;

        #endregion

        #region Global game state

        public static int Day { get; private set; } = 1;
        public static int TotalScore { get; private set; } = 0;
        public static int CurrentBallance { get; private set; } = 0;
        public static bool IsGameOver { get; private set; } = false;

        #endregion


        #region Turn based props

        public static List<Card> Hand { get; set; } = new List<Card>();
        public static List<Card> Altar { get; set; } = new List<Card>();
        public static int AvailableEnergy { get; set; }
        #endregion


        #region Game Control

        //TODO scoring nakon svakog turna za score;
        public static void StartNewGame()
        {
            Day = 1;
            TotalScore = 0;
            CurrentBallance = 0;
            IsGameOver = false;

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

            AvailableEnergy = EnergyAvailableEachTurn;
            DrawCards(5);
        }

        public static void DrawCards(int numberOfCardsToDraw)
        {
            if (Deck.ShuffledDeck.Count < numberOfCardsToDraw)
            {
                //TODO vidjeti kaj napraviti ak nema dosta karti
                throw new Exception("Not enough cards in the deck.");
            }

            var newCards = Deck.ShuffledDeck.Take(numberOfCardsToDraw).ToList();

            Hand.AddRange(newCards);

            foreach (var card in newCards)
            {
                Deck.ShuffledDeck.Remove(card);
            }

            Console.WriteLine("nekaj");
        }

        #endregion

        #region Player Actions

        public static bool MoveHandToAltar(Card card) //Todo zamjeni dynamic s klasom
        {
            //TODO mozda dodati se se salje i tekst u ovisnosti radi cega nemre
            //ili se sam prikze genericki tekst da nemre to npraviti
            if (AvailableEnergy <= 0) return false;
            if (Altar.Count >= MaxAltarSize) return false;
            if (!Hand.Contains(card)) return false; // ak slucajne neke sjebeme na fronte

            Hand.Remove(card);
            Altar.Add(card);
            AvailableEnergy--;

            return true;
        }

        public static bool DiscardFromAltar(Card card) //Todo zamjeni dynamic s klasom
        {
            //TODO mozda dodati se se salje i tekst u ovisnosti radi cega nemre
            //ili se sam prikze genericki tekst da nemre to npraviti
            if (AvailableEnergy <= 0) return false;
            if (!Altar.Contains(card)) return false; // ak se slucajne neke sjebe na fronte

            Altar.Remove(card);
            AvailableEnergy--;

            return true;
        }

        public static bool MoveAltarToHand(Card card) //Todo zamjeni dynamic s klasom
        {
            if (AvailableEnergy <= 0) return false;
            if (!Altar.Contains(card)) return false;

            Altar.Remove(card);
            Hand.Add(card);

            AvailableEnergy--;

            return true;
        }

        #endregion


        #region End Turn Logic

        public static void EndTurn()
        {
            CalculateScore();

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

        private static void CalculateScore()
        {
            int sum = 0;
            foreach (var card in Hand)
            {
                sum += card.Value;
            }

            CurrentBallance = sum;

            //ak je igrac udaljen za 3 od 0 onda dobije 7 itd, treba jos videti
            int distanceFromZero = Math.Abs(sum);
            int roundScore = 10 - distanceFromZero;
            if (roundScore < 0) roundScore = 0;

            TotalScore += roundScore;
        }

        #endregion

    }
}
