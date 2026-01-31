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

namespace WinFormsApp1.Forms
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
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
        }
    }
}
