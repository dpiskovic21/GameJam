using WinFormsApp1.Assets;

namespace WinFormsApp1.Forms
{
    public partial class LoadingForm : Form
    {
        private bool _initialised = false;
        public LoadingForm()
        {
            InitializeComponent();
            var bit = new Bitmap($"..\\..\\..\\resources\\arena-big-blur.png");
            this.BackgroundImage = new Bitmap(bit, this.Size);
        }

        public async Task SetupComponents()
        {
            _initialised = true;
            labelLoading.ForeColor = Color.Black;
            labelLoading.BackColor = Color.Transparent;
            labelLoading.Font = CustomFont.GetCustomFontBySize(50);

            int targetW = MainForm.PnlContainer.ClientSize.Width;
            int targetH = MainForm.PnlContainer.ClientSize.Height;
            labelLoading.Left = (targetW - labelLoading.Width) / 2;
            labelLoading.Top = (targetH - labelLoading.Height) / 2;
        }

        private async void LoadingForm_Load(object sender, EventArgs e)
        {

            if (!_initialised)
            {
                await SetupComponents();
            }
            var form = new MainPlayAreaForm();

            await form.SetupComponentsAsync();
            MainForm.SetNewForm(form);
        }
    }
}
