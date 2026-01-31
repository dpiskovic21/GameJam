using WinFormsApp1.Assets;
using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();

            btnStart.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", btnStart.Height + 75, btnStart.Width + 125);
            btnExit.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", btnExit.Height * 2, btnExit.Width * 2);
            btnLeaderboard.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", btnLeaderboard.Height * 2, btnLeaderboard.Width * 2);
            btnStart.ForeColor = Color.White;
            btnExit.ForeColor = Color.White;
            btnLeaderboard.ForeColor = Color.White;
            btnStart.Font = CustomFont.GetCustomFontBySize(16);
            btnExit.Font = CustomFont.GetCustomFontBySize(16);
            btnLeaderboard.Font = CustomFont.GetCustomFontBySize(16);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var form = new LoadingForm();
            form.SetupComponents().GetAwaiter().GetResult();
            MainForm.SetNewForm(form);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void StartMenuForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Deck.ResizeCardImage($"..\\..\\..\\resources\\main-menu.png", this.Parent!.Height, this.Parent.Width);
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            MainForm.SetNewForm(new Leaderboard());
        }
    }
}
