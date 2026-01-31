using WinFormsApp1.models;

namespace WinFormsApp1.Forms
{
    public partial class EndForm : Form
    {
        public EndForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.SetNewForm(new StartMenuForm());
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Deck.ResizeCardImage($"..\\..\\..\\resources\\arena-big-blur.png", this.Parent!.Height, this.Parent.Width);
        }
    }
}
