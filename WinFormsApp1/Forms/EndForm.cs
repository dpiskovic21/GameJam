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
    }
}
