using WinFormsApp1.Assets;
using WinFormsApp1.Game;
using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class MainPlayAreaForm : Form
    {
        private Card? cardHandBeingReplaced = null;
        private Button[] handCards;
        private Button[] altarCards;
        private ContextMenuStrip contextMenu;

        public MainPlayAreaForm()
        {
            InitializeComponent();

            gpReplacePrompt.Hide();
            GameState.StartNewGame();

            btnDeck.Image = Deck.CardBackImage;
            handCards = new[] { handCard1, handCard2, handCard3, handCard4, handCard5 };
            altarCards = new[] { altarCard1, altarCard2, altarCard3 };

            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i].Click += (s, e) => OnHandCardClick(s as Button);
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                altarCards[i].Click += (s, e) => OnAltarCardClick(s as Button);
            }

            UpdateAll();
            GameState.OnScoreProcessed += HandleScoreProcessed;
        }

        public void UpdateAll()
        {
            UpdateHand();
            UpdateUI();
        }

        private void HandleScoreProcessed(int score)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleScoreProcessed(score)));
                return;
            }

            //labelScore.Text = $"Dobiveni bodovi: {score}";
            labelScore.Text = $"Ukupno: {GameState.TotalScore}";
        }

        public void UpdateHand()
        {
            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i].Tag = GameState.Hand.ElementAtOrDefault(i);
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                altarCards[i].Tag = GameState.Altar.ElementAtOrDefault(i);
            }

            labelCurrentHandBalance.Text = "Current hand balance: " + GameState.Hand.Select(x => x?.Value ?? 0).Sum().ToString();
            labelCurrentHandBalance.Font = new Font(CustomFont.pfc.Families[0], 10);
            btnDeck.Text = Deck.ShuffledDeck.Count.ToString() + " / 60";
            labelEnergy.Text = GameState.AvailableEnergy + " Energy Remaining";
            labelDay.Text = "Day " + GameState.Day + " / 7";
            labelCurrentBalance.Text = "Current balance " + GameState.CurrentBalance;
        }

        public void UpdateUI()
        {
            for (int i = 0; i < handCards.Length; i++)
            {
                var card = ((handCards[i].Tag) as Card);
                handCards[i].Image = card?.CardImage ?? Deck.CardPlaceholderImage;
                if (card != null)
                {
                    handCards[i].Enabled = !card.IsLocked;
                }
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                altarCards[i].Image = ((altarCards[i].Tag) as Card)?.CardImage ?? Deck.CardPlaceholderImage;
            }
        }

        private void OnHandCardClick(Button handCardControl)
        {
            Card? card = handCardControl.Tag as Card;
            if (card == null)
            {
                return;
            }

            contextMenu = new ContextMenuStrip();

            var optionMoveToAltar = new ToolStripMenuItem("Move to altar (1 energy)");
            optionMoveToAltar.Enabled = GameState.AvailableEnergy > 0;

            optionMoveToAltar.Click += (s, e) => MoveHandToAltar(card);
            contextMenu.Items.AddRange(new ToolStripItem[] { optionMoveToAltar });

            contextMenu.Show(handCardControl, new Point(0, handCardControl.Height));

        }

        private void OnAltarCardClick(Button altarCardControl)
        {
            Card? card = altarCardControl.Tag as Card;
            if (card == null)
            {
                return;
            }

            contextMenu = new ContextMenuStrip();

            var optionDiscard = new ToolStripMenuItem("Discard card (1 energy)");
            var optionMoveToHand = new ToolStripMenuItem("Move to hand (0 energy)");
            optionDiscard.Enabled = GameState.AvailableEnergy > 0;
            optionMoveToHand.Enabled = true;

            optionDiscard.Click += (s, e) => DiscardAltarCard(card);
            optionMoveToHand.Click += (s, e) => MoveAltarToHand(card);
            contextMenu.Items.AddRange(new ToolStripItem[] { optionDiscard });
            contextMenu.Items.AddRange(new ToolStripItem[] { optionMoveToHand });


            contextMenu.Show(altarCardControl, new Point(0, altarCardControl.Height));

        }


        private void MoveHandToAltar(Card card)
        {
            if (card != null)
            {
                GameState.MoveHandToAltar(card);
                UpdateAll();
            }
        }
        private void MoveAltarToHand(Card card)
        {
            if (card != null)
            {
                GameState.MoveAltarToHand(card);
                UpdateAll();
            }
        }


        private void DiscardAltarCard(Card card)
        {
            if (card != null)
            {
                GameState.DiscardFromAltar(card);
                UpdateAll();
            }

        }

        private void btnDeck_Click(object sender, EventArgs e)
        {
            GameState.DrawCards(1);
            UpdateAll();
        }

        private void btnEndRound_Click(object sender, EventArgs e)
        {
            GameState.EndTurn();
            if (GameState.IsGameOver)
            {
                MainForm.SetNewForm(new EndForm());
            }
            UpdateAll();
        }

        private void btnCancelSwap_Click(object sender, EventArgs e)
        {
            this.cardHandBeingReplaced = null;
            gpReplacePrompt.Hide();
        }

        private void MainPlayAreaForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Deck.ResizeCardImage($"..\\..\\..\\resources\\arena.jpg", this.Parent.Height, this.Parent.Width);
            labelCurrentHandBalance.Font = new Font(CustomFont.pfc.Families[0], 16);
            btnCancelSwap.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", btnCancelSwap.Height, btnCancelSwap.Width);
        }
    }
}
