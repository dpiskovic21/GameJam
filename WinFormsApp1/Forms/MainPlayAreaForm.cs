using WinFormsApp1.Game;
using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class MainPlayAreaForm : Form
    {
        public MainPlayAreaForm()
        {
            InitializeComponent();
            GameState.StartNewGame();

            btnDeck.Image = GameState.CardBackImage;

            UpdateHand();
            UpdateUI();
        }

        public void UpdateHand()
        {
            handCard1.Tag = GameState.Hand.ElementAt(0);
            handCard2.Tag = GameState.Hand.ElementAt(1);
            handCard3.Tag = GameState.Hand.ElementAt(2);
            handCard4.Tag = GameState.Hand.ElementAt(3);
            handCard5.Tag = GameState.Hand.ElementAt(4);
        }

        public void UpdateUI()
        {
            handCard1.Image = ((handCard1.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard2.Image = ((handCard2.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard3.Image = ((handCard3.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard4.Image = ((handCard4.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard5.Image = ((handCard5.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
        }
    }
}
