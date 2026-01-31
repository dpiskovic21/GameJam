using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.models;
using WinFormsApp1.service;

namespace WinFormsApp1.Forms
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
            LoadLeaderboardEntries();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            var originalImage = Deck.ResizeCardImage($"..\\..\\..\\resources\\main-menu.png", this.Parent!.Height, this.Parent.Width);

            Bitmap darkenedImage = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(darkenedImage))
            {
                g.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);

                using (Brush darkBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                {
                    g.FillRectangle(darkBrush, 0, 0, originalImage.Width, originalImage.Height);
                }
            }

            this.BackgroundImage = darkenedImage;

            btnExit.Image = Deck.ResizeCardImage($"..\\..\\..\\resources\\button.jpg", btnExit.Height * 2, btnExit.Width * 2);
            btnExit.ForeColor = Color.White;
        }

        private async void LoadLeaderboardEntries()
        {
            this.StyleDataGridView();

            List<LeaderboardDTO> entries = await GoogleSheetService.getLeaderboardEntries();

            dgvLeaderboard.DataSource = entries.Select(e => new
            {
                Username = e.username,
                Score = e.score,
            })
                .ToList();
        }

        private void StyleDataGridView()
        {
            dgvLeaderboard.EnableHeadersVisualStyles = false;

            dgvLeaderboard.BackgroundColor = Color.Black;
            dgvLeaderboard.BorderStyle = BorderStyle.None;

            dgvLeaderboard.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeaderboard.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvLeaderboard.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0, 0);
            dgvLeaderboard.DefaultCellStyle.ForeColor = Color.White;
            dgvLeaderboard.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 255, 255, 255);
            dgvLeaderboard.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvLeaderboard.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 0, 0, 0);
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLeaderboard.AllowUserToResizeRows = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var form = new StartMenuForm();
            MainForm.SetNewForm(form);
        }
    }
}
