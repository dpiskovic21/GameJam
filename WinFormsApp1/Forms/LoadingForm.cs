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
            var form = new MainPlayAreaForm();

            await form.SetupComponentsAsync();

            MainForm.SetNewForm(form);

        }
    }
}
