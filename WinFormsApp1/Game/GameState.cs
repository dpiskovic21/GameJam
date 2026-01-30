namespace WinFormsApp1.Game
{
    public static class GameState
    {
        #region global info (immutable)

        public const int EnergyAvailableEachTurn = 5;

        #endregion

        #region Global game state

        public static int Day = 1; //1-7
        public static int Score = 0;
        public static int Balance = 0; //light dark balance (-10,10)?

        #endregion


        #region Turn based props

        public static dynamic Hand { get; set; } //TODO ovo je 5 karti u ruci
        public static dynamic Altar { get; set; } //TODO ovo je 3 karti na altaru ili kaj vec
        public static int AvailableEnergy { get; set; }
        #endregion


        #region actions

        //TODO scoring nakon svakog turna za score;

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

        public static void Draw()
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
