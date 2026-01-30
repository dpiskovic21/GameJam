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
            btnStart.ForeColor = Color.White;
            btnExit.ForeColor = Color.White;
            btnStart.Font = CustomFont.GetCustomFontBySize(16);
            btnExit.Font = CustomFont.GetCustomFontBySize(16);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MainForm.SetNewForm(new LoadingForm());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void StartMenuForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Deck.ResizeCardImage($"..\\..\\..\\resources\\main-menu.png", this.Parent!.Height, this.Parent.Width);
        }
    }
}
