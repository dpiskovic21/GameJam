namespace WinFormsApp1.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {
            await System.Threading.Tasks.Task.Delay(500);

            MainForm.SetNewForm(new MainPlayAreaForm());
        }
    }
}
