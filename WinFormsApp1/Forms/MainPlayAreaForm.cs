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

            btnDeck.Image = GameState.CardBackImage;
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
        }

        public void UpdateAll()
        {
            UpdateHand();
            UpdateUI();
        }

        private void GameState_OnScoreProcessed(int score)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => GameState_OnScoreProcessed(score)));
                return;
            }

            labelCurrentBalance.Text = $"Dobiveni bodovi: {score}";
            labelCurrentBalance.Text = $"Ukupno: {GameState.TotalScore}";
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
            btnDeck.Text = Deck.ShuffledDeck.Count.ToString() + " / 60";
            labelEnergy.Text = GameState.AvailableEnergy + " Energy Remaining";
            labelDay.Text = "Day " + GameState.Day + " / 7";
            //labelCurrentBalance.Text = "Current balance " + GameState.CurrentBalance;
        }

        public void UpdateUI()
        {
            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i].Image = ((handCards[i].Tag) as Card)?.CardImage ?? GameState.CardBackImage;
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                altarCards[i].Image = ((altarCards[i].Tag) as Card)?.CardImage ?? GameState.CardBackImage;
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
            var optionReplaceWithAltarCard = new ToolStripMenuItem("Replace with altar card (0 energy)");

            optionMoveToAltar.Click += (s, e) => MoveHandToAltar(card);
            optionReplaceWithAltarCard.Click += (s, e) => ReplaceWithAltarCard(card);

            contextMenu.Items.AddRange(new ToolStripItem[] { optionMoveToAltar, optionReplaceWithAltarCard });
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
            var optionReplace = new ToolStripMenuItem("Replace");
            optionDiscard.Enabled = GameState.AvailableEnergy > 0;

            optionDiscard.Click += (s, e) => DiscardAltarCard(card);
            optionReplace.Click += (s, e) => SwapHandAndAltarCards(card);
            contextMenu.Items.AddRange(new ToolStripItem[] { optionDiscard });

            if (this.cardHandBeingReplaced != null)
            {
                contextMenu.Items.Add(optionReplace);
            }

            contextMenu.Show(altarCardControl, new Point(0, altarCardControl.Height));

        }

        private void SwapHandAndAltarCards(Card card)
        {

            if (this.cardHandBeingReplaced != null)
            {
                GameState.SwapHandAndAltarCards(this.cardHandBeingReplaced, card);
                gpReplacePrompt.Hide();
                UpdateAll();
            }
        }

        private void MoveHandToAltar(Card card)
        {
            if (card != null)
            {
                GameState.MoveHandToAltar(card);
                UpdateAll();
            }
        }

        private void ReplaceWithAltarCard(Card card)
        {
            if (card == null)
            {
                return;
            }
            this.cardHandBeingReplaced = card;
            gpReplacePrompt.Show();
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
    }
}
