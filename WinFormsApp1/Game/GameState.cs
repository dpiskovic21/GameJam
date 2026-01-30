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


        #region actions

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

        public static void PlaceCardOnAltar(dynamic card) //Todo zamjeni dynamic s klasom
        {
            //treba neke vratit?
        }

        public static void DiscardFromAltar(dynamic card) //Todo zamjeni dynamic s klasom
        {

        }

        public static void ReplaceHandAndAltarCards(dynamic cardHand, dynamic cardAltar) //Todo zamjeni dynamic s klasom
        {

        }

        private static void PerformAction()
        {
            if (GameState.AvailableEnergy == 0)
            {
                //nekak alert?
                return;
            }

            //...
        }

        public static void EndTurn()
        {
            GameState.Day++;
        }

        #endregion

    }
}
