using WinFormsApp1.Assets;
using WinFormsApp1.Game;
using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class EndForm : Form
    {
        private bool _inisitalised = false;

        public EndForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.SetNewForm(new StartMenuForm());
            SFX.StopMusic();
            SFX.PlayMusicLoop("..\\..\\..\\resources\\music\\ambient.wav", 0.2f);
        }

        public async Task SetupFormComponents()
        {
            this.SuspendLayout();
            int targetW = MainForm.PnlContainer.ClientSize.Width;
            int targetH = MainForm.PnlContainer.ClientSize.Height;
            labelScore.Text = "Total Score: " + GameState.TotalScore;
            this.BackgroundImage = Deck.ResizeCardImage($"..\\..\\..\\resources\\arena-big-blur.png", targetH, targetW);
            labelOver.Font = CustomFont.GetCustomFontBySize(100);
            labelScore.Font = CustomFont.GetCustomFontBySize(50);

            labelScore.Top = (targetH - labelOver.Height) / 2;
            labelOver.Top = (targetH - labelOver.Height) / 4;
            button1.Top = (targetH - button1.Height) / 2 + 200;
            labelOver.Left = (targetW - labelOver.Width) / 2;
            labelScore.Left = (targetW - labelOver.Width) / 2;
            button1.Left = (targetW - button1.Width) / 2;
            button1.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", button1.Height * 2, button1.Width * 2);
            button1.ForeColor = Color.White;
            button1.Font = CustomFont.GetCustomFontBySize(16);
            labelOver.BackColor = Color.Transparent;
            labelScore.BackColor = Color.Transparent;
            this._inisitalised = true;
            this.ResumeLayout();
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            if (!_inisitalised)
            {
                this.SetupFormComponents();
            }
        }
    }
}
