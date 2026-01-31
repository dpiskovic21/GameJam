using WinFormsApp1.Assets;
using WinFormsApp1.enums;
using WinFormsApp1.Game;
using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class MainPlayAreaForm : Form
    {
        private Button[] handCards = [];
        private Button[] altarCards = [];
        private ContextMenuStrip? contextMenu = null;
        private bool _initialized = false;
        private ToolTip tooltip;

        #region NE DIRAJ, OPTIMIZACIJA UCITAVANJA DA SMANJI FLICKERING
        public MainPlayAreaForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        public async Task SetupComponentsAsync()
        {
            if (_initialized)
                return;

            _initialized = true;

            this.SuspendLayout();
            this.tooltip = new ToolTip();
            pbPeekCard.Hide();

            flowLayoutPanel1.BorderStyle = BorderStyle.None;
            flowLayoutPanel2.BorderStyle = BorderStyle.None;
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom;
            flowLayoutPanel2.Anchor = AnchorStyles.Top;

            // BUTTONS
            btnDeck.Image = Deck.CardBackImage;
            btnDeck.Font = CustomFont.GetCustomFontBySize(20);
            btnDeck.FlatStyle = FlatStyle.Flat;
            btnDeck.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 128);
            btnDeck.FlatAppearance.BorderSize = 2;
            btnEndRound.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", btnEndRound.Height + 75, btnEndRound.Width + 125);
            btnEndRound.ForeColor = Color.White;
            btnEndRound.Font = CustomFont.GetCustomFontBySize(16);
            // FONTS
            labelCurrentHandBalance.Font = CustomFont.GetCustomFontBySize(18);
            labelCurrentBalance.Font = CustomFont.GetCustomFontBySize(22);
            labelDay.Font = CustomFont.GetCustomFontBySize(50);
            labelEnergy.Font = CustomFont.GetCustomFontBySize(22);
            labelCurrentModifier.Font = CustomFont.GetCustomFontBySize(18);
            labelScore.Font = CustomFont.GetCustomFontBySize(22);

            //LABELS
            labelCurrentHandBalance.BackColor = Color.Transparent;
            labelCurrentBalance.BackColor = Color.Transparent;
            labelScore.BackColor = Color.Transparent;
            labelEnergy.BackColor = Color.Transparent;
            labelCurrentModifier.BackColor = Color.Transparent;
            labelDay.BackColor = Color.Transparent;
            labelScore.BackColor = Color.Transparent;

            handCards = new[] { handCard1, handCard2, handCard3, handCard4, handCard5 };
            altarCards = new[] { altarCard1, altarCard2, altarCard3 };

            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i].Click -= HandCard_Click_Wrapper;
                handCards[i].Click += HandCard_Click_Wrapper;
                handCards[i].MouseEnter -= Card_MouseEnter;
                handCards[i].MouseEnter += Card_MouseEnter;
                handCards[i].MouseLeave -= Card_MouseLeave;
                handCards[i].MouseLeave += Card_MouseLeave;
                handCards[i].FlatStyle = FlatStyle.Flat;
                handCards[i].FlatAppearance.BorderColor = Color.FromArgb(128, 128, 128);
                handCards[i].FlatAppearance.BorderSize = 2;
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                altarCards[i].Click -= AltarCard_Click_Wrapper;
                altarCards[i].Click += AltarCard_Click_Wrapper;
                altarCards[i].MouseEnter -= Card_MouseEnter;
                altarCards[i].MouseEnter += Card_MouseEnter;
                altarCards[i].MouseLeave -= Card_MouseLeave;
                altarCards[i].MouseLeave += Card_MouseLeave;
                altarCards[i].FlatStyle = FlatStyle.Flat;
                altarCards[i].FlatAppearance.BorderColor = Color.FromArgb(128, 128, 128);
                altarCards[i].FlatAppearance.BorderSize = 2;
            }

            GameState.StartNewGame();

            int targetW = MainForm.PnlContainer.ClientSize.Width;
            int targetH = MainForm.PnlContainer.ClientSize.Height;

            flowLayoutPanel1.Left = (targetW - flowLayoutPanel1.Width) / 2;
            flowLayoutPanel1.Top = targetH - flowLayoutPanel1.Height - 20;
            flowLayoutPanel2.Left = (targetW - flowLayoutPanel2.Width) / 2;
            flowLayoutPanel2.Top = 200;


            var path = Path.Combine("..", "..", "..", "resources", "arena-blur.png");

            this.BackgroundImage = await Task.Run(() => Deck.ResizeCardImage(path, targetH, targetW));

            UpdateAll();

            this.ResumeLayout(true);

        }

        private void HandCard_Click_Wrapper(object? sender, EventArgs e)
        {
            if (sender is Button b)
                OnHandCardClick(b);
        }

        private void Card_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var card = button.Tag as Card;
                if (card != null)
                {
                    var cardValue = card.Value;

                    if ((GameState.RoundModifier == RoundModifierEnum.LightDoubleValue && card.CardTypeEnum == CardTypeEnum.Light) || (GameState.RoundModifier == RoundModifierEnum.DarkDoubleValue && card.CardTypeEnum == CardTypeEnum.Dark))
                    {
                        cardValue *= 2;
                    }
                    tooltip.Show("Card Value: " + cardValue, button, 0, -25);
                }
            }
        }

        private void Card_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                tooltip.Hide(button);
            }
        }


        private void AltarCard_Click_Wrapper(object? sender, EventArgs e)
        {
            if (sender is Button b)
                OnAltarCardClick(b);
        }

        #endregion

        public void UpdateAll()
        {
            UpdateHandAndAltarCards();
            UpdateUI();
        }

        public void UpdateHandAndAltarCards()
        {
            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i].Tag = GameState.Hand.ElementAtOrDefault(i);
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                altarCards[i].Tag = GameState.Altar.ElementAtOrDefault(i);
            }
        }

        public void UpdateUI()
        {
            for (int i = 0; i < handCards.Length; i++)
            {
                var card = (handCards[i].Tag) as Card;
                handCards[i].Image = card?.CardImage ?? Deck.CardPlaceholderImage;
                if (card != null)
                {
                    handCards[i].Enabled = !card.IsLocked;
                }
                else
                {
                    handCards[i].Enabled = true;
                }
            }

            for (int i = 0; i < altarCards.Length; i++)
            {
                var card = ((altarCards[i].Tag) as Card);
                altarCards[i].Image = card?.CardImage ?? Deck.CardPlaceholderImage;
                if (card != null)
                {
                    altarCards[i].Enabled = !card.IsLocked;
                }
            }

            labelCurrentHandBalance.Text = "Current Hand Balance: " + GameState.CurrentHandBalance;
            btnDeck.Text = Deck.ShuffledDeck.Count.ToString() + " / 60";
            labelEnergy.Text = GameState.AvailableEnergy + " / " + GameState.EnergyAvailableEachTurn + " Energy Remaining This Turn";
            labelDay.Text = "Day " + GameState.Day + " / 7";
            labelCurrentBalance.Text = "Global Balance " + GameState.CurrentBalance;
            labelCurrentModifier.Text = "Current Round Modifier: " + GameState.RoundModifier.GetDisplayName();
            labelScore.Text = "Total Score: " + GameState.TotalScore;
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
            optionMoveToAltar.Font = CustomFont.GetCustomFontBySize(10);
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
            optionDiscard.Font = CustomFont.GetCustomFontBySize(10);
            var optionMoveToHand = new ToolStripMenuItem("Move to hand (0 energy)");
            optionMoveToHand.Font = CustomFont.GetCustomFontBySize(10);
            optionDiscard.Enabled = GameState.AvailableEnergy > 0;
            optionMoveToHand.Enabled = true;

            optionDiscard.Click += (s, e) => DiscardAltarCard(card);
            optionMoveToHand.Click += (s, e) => MoveAltarToHand(card);
            contextMenu.Items.Add(optionDiscard);

            if (GameState.Hand.Count < GameState.MaxHandSize)
            {
                contextMenu.Items.Add(optionMoveToHand);
            }

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
                var form = new EndForm();
                form.SetupFormComponents().GetAwaiter().GetResult();
                MainForm.SetNewForm(form);
            }
            UpdateAll();
        }

        private void btnDeck_MouseEnter(object sender, EventArgs e)
        {
            var card = GameState.PeekFirstCard();
            if (card == null)
            {
                return;
            }

            pbPeekCard.Image = card.CardImage;
            pbPeekCard.Show();
        }

        private void btnDeck_MouseLeave(object sender, EventArgs e)
        {
            pbPeekCard.Hide();
        }

        private async void MainPlayAreaForm_Load(object sender, EventArgs e)
        {
            SFX.StopMusic();
            SFX.PlayMusicLoop($"..\\..\\..\\resources\\main_game_music.wav", volume: 0.05f);
            if (!_initialized)
            {
                await SetupComponentsAsync();
            }
        }
    }
}
