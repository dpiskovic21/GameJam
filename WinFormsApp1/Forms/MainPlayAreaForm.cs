using WinFormsApp1.Game;
using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class MainPlayAreaForm : Form
    {

        ContextMenuStrip contextMenuStrip1;
        ContextMenuStrip contextMenuStrip2;
        ContextMenuStrip contextMenuStrip3;
        ContextMenuStrip contextMenuStrip4;
        ContextMenuStrip contextMenuStrip5;

        Card? cardHandBeingReplaced = null;

        public MainPlayAreaForm()
        {
            InitializeComponent();
            gpReplacePrompt.Hide();
            GameState.StartNewGame();

            btnDeck.Image = GameState.CardBackImage;

            UpdateHand();
            UpdateUI();
        }


        public void UpdateAll()
        {
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

            labelCurrentHandBalance.Text = "Current hand balance: " + GameState.Hand.Select(x => x?.Value ?? 0).Sum().ToString();
            btnDeck.Text = Deck.ShuffledDeck.Count.ToString() + " / 60";
            labelEnergy.Text = GameState.AvailableEnergy + " Energy Remaining";
            labelDay.Text = "Day " + GameState.Day + " / 7";
            labelCurrentBalance.Text = "Current balance " + GameState.CurrentBalance;
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

        #region REFACTOR
        private void handCard1_Click(object sender, EventArgs e)
        {
            Card? card = handCard1.Tag as Card;

            contextMenuStrip1 = new ContextMenuStrip();

            var optionMoveToAltar = new ToolStripMenuItem("Move to altar");
            var optionReplaceWithAltarCard = new ToolStripMenuItem("Replace with altar card");

            optionMoveToAltar.Click += (s, e) =>
            {
                MoveHandToAltar(card);
            };
            optionReplaceWithAltarCard.Click += (s, e) =>
            {
                ReplaceWithAltarCard(card);
            };

            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { optionMoveToAltar, optionReplaceWithAltarCard });
            contextMenuStrip1.Show(handCard1, new Point(0, handCard1.Height));
        }

        private void handCard2_Click(object sender, EventArgs e)
        {
            Card? card = handCard2.Tag as Card;

            contextMenuStrip2 = new ContextMenuStrip();

            var optionMoveToAltar = new ToolStripMenuItem("Move to altar");
            var optionReplaceWithAltarCard = new ToolStripMenuItem("Replace with altar card");

            optionMoveToAltar.Click += (s, e) =>
            {
                MoveHandToAltar(card);
            };
            optionReplaceWithAltarCard.Click += (s, e) =>
            {
                ReplaceWithAltarCard(card);
            };

            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { optionMoveToAltar, optionReplaceWithAltarCard });
            contextMenuStrip2.Show(handCard2, new Point(0, handCard2.Height));
        }

        private void handCard3_Click(object sender, EventArgs e)
        {
            Card? card = handCard3.Tag as Card;

            contextMenuStrip3 = new ContextMenuStrip();

            var optionMoveToAltar = new ToolStripMenuItem("Move to altar");
            var optionReplaceWithAltarCard = new ToolStripMenuItem("Replace with altar card");

            optionMoveToAltar.Click += (s, e) =>
            {
                MoveHandToAltar(card);
            };
            optionReplaceWithAltarCard.Click += (s, e) =>
            {
                ReplaceWithAltarCard(card);
            };

            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { optionMoveToAltar, optionReplaceWithAltarCard });
            contextMenuStrip3.Show(handCard3, new Point(0, handCard3.Height));

        }

        private void handCard4_Click(object sender, EventArgs e)
        {
            Card? card = handCard4.Tag as Card;

            contextMenuStrip4 = new ContextMenuStrip();

            var optionMoveToAltar = new ToolStripMenuItem("Move to altar");
            var optionReplaceWithAltarCard = new ToolStripMenuItem("Replace with altar card");

            optionMoveToAltar.Click += (s, e) =>
            {
                MoveHandToAltar(card);
            };
            optionReplaceWithAltarCard.Click += (s, e) =>
            {
                ReplaceWithAltarCard(card);
            };

            contextMenuStrip4.Items.AddRange(new ToolStripItem[] { optionMoveToAltar, optionReplaceWithAltarCard });
            contextMenuStrip4.Show(handCard4, new Point(0, handCard4.Height));
        }

        private void handCard5_Click(object sender, EventArgs e)
        {
            Card? card = handCard5.Tag as Card;

            contextMenuStrip5 = new ContextMenuStrip();

            var optionMoveToAltar = new ToolStripMenuItem("Move to altar");
            var optionReplaceWithAltarCard = new ToolStripMenuItem("Replace with altar card");

            optionMoveToAltar.Click += (s, e) =>
            {
                MoveHandToAltar(card);
            };
            optionReplaceWithAltarCard.Click += (s, e) =>
            {
                ReplaceWithAltarCard(card);
            };

            contextMenuStrip5.Items.AddRange(new ToolStripItem[] { optionMoveToAltar, optionReplaceWithAltarCard });
            contextMenuStrip5.Show(handCard5, new Point(0, handCard5.Height));
        }

        #endregion

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

        private void btnDeck_Click(object sender, EventArgs e)
        {
            GameState.DrawCards(1);
            UpdateAll();
        }

        private void btnEndRound_Click(object sender, EventArgs e)
        {
            GameState.EndTurn();
            UpdateAll();
        }

        private void altarCard1_Click(object sender, EventArgs e)
        {
            Card? card = (altarCard1.Tag as Card);
            if (card == null)
            {
                return;
            }


            if (this.cardHandBeingReplaced != null)
            {
                GameState.SwapHandAndAltarCards(this.cardHandBeingReplaced, card);
                gpReplacePrompt.Hide();
                UpdateAll();
            }
            else
            {
                GameState.DiscardFromAltar(card);
                UpdateAll();
            }

        }

        private void altarCard2_Click(object sender, EventArgs e)
        {
            Card? card = (altarCard2.Tag as Card);
            if (card == null)
            {
                return;
            }


            if (this.cardHandBeingReplaced != null)
            {
                GameState.SwapHandAndAltarCards(this.cardHandBeingReplaced, card);
                gpReplacePrompt.Hide();
                UpdateAll();
            }
            else
            {
                GameState.DiscardFromAltar(card);
                UpdateAll();
            }

        }

        private void altarCard3_Click(object sender, EventArgs e)
        {
            Card? card = (altarCard3.Tag as Card);
            if (card == null)
            {
                return;
            }


            if (this.cardHandBeingReplaced != null)
            {
                GameState.SwapHandAndAltarCards(this.cardHandBeingReplaced, card);
                gpReplacePrompt.Hide();
                UpdateAll();
            }
            else
            {
                GameState.DiscardFromAltar(card);
                UpdateAll();
            }

        }

        private void btnCancelSwap_Click(object sender, EventArgs e)
        {
            this.cardHandBeingReplaced = null;
            gpReplacePrompt.Hide();
        }
    }
}
