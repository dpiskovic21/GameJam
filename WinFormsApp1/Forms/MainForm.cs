using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private static Form activeForm = null;
        private static Panel _pnlContainer;

        public MainForm()
        {
            InitializeComponent();
            MainForm._pnlContainer = pnlContainer;
            MainForm.SetNewForm(new StartMenuForm());
        }

        public static void SetNewForm(Form childForm)
        {
            CloseActiveForm();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            MainForm._pnlContainer.Controls.Add(childForm);
            MainForm._pnlContainer.Tag = childForm;

            childForm.Show();
            childForm.BringToFront();

            MainForm.activeForm = childForm;
        }

        private static void CloseActiveForm()
        {
            if (MainForm.activeForm != null)
            {
                MainForm.activeForm.Close();
                MainForm._pnlContainer.Controls.Remove(MainForm.activeForm);
                MainForm.activeForm = null;
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseActiveForm();
            base.OnFormClosing(e);
        }


        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (activeForm != null)
            {
                activeForm.Focus();
            }
        }
    }
}
