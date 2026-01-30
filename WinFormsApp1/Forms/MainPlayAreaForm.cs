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
            handCard1.Tag = GameState.Hand.ElementAtOrDefault(0);
            handCard2.Tag = GameState.Hand.ElementAtOrDefault(1);
            handCard3.Tag = GameState.Hand.ElementAtOrDefault(2);
            handCard4.Tag = GameState.Hand.ElementAtOrDefault(3);
            handCard5.Tag = GameState.Hand.ElementAtOrDefault(4);

            altarCard1.Tag = GameState.Altar.ElementAtOrDefault(0);
            altarCard2.Tag = GameState.Altar.ElementAtOrDefault(1);
            altarCard3.Tag = GameState.Altar.ElementAtOrDefault(2);

            labelCurrentHandBalance.Text = "Current hand balance: " + GameState.Hand.Select(x => x.Value).Sum().ToString();
            btnDeck.Text = Deck.ShuffledDeck.Count.ToString() + " / 60";
            labelEnergy.Text = GameState.AvailableEnergy + " Energy Remaining";
        }

        public void UpdateUI()
        {
            handCard1.Image = ((handCard1.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard2.Image = ((handCard2.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard3.Image = ((handCard3.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard4.Image = ((handCard4.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            handCard5.Image = ((handCard5.Tag) as Card)?.CardImage ?? GameState.CardBackImage;

            altarCard1.Image = ((altarCard1.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            altarCard2.Image = ((altarCard2.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            altarCard3.Image = ((altarCard3.Tag) as Card)?.CardImage ?? GameState.CardBackImage;
        }
    }
}
