namespace WinFormsApp1.Forms
{
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Show the loading form inside the main form's panel so it displays properly
            MainForm.SetNewForm(new LoadingForm());
        }

        private void StartMenuForm_Load(object sender, EventArgs e)
        {
            // Center the button within the form's client area so it looks good when docked
            btnStart.Left = (this.ClientSize.Width - btnStart.Width) / 2;
            btnStart.Top = (this.ClientSize.Height - btnStart.Height) / 2;
        }
    }
}
