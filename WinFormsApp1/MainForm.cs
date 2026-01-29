using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.enums;
using WinFormsApp1.models;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.InitializeDeck();
        }

        private void InitializeDeck()
        {
            List<Card> initDeck = new List<Card>();

            for (int i = 0; i < 6; i++)
            {
                for (int j = -5; j < 6; j++)
                {
                    CardTypeEnum cardType = CardTypeEnum.Light;
                    if (j == 0)
                    {
                        continue;
                    }

                    if (j < 0)
                    {
                        cardType = CardTypeEnum.Dark;
                    }

                    Card card = new Card()
                    {
                        Value = j,
                        CardBackImagePath = "..\\..\\..\\resources\\placeholder.png",
                        CardTypeEnum = cardType,
                        CardImage = new Bitmap("..\\..\\..\\resources\\placeholder.png")
                    };

                    initDeck.Add(card);
                }
            }

            Deck.Cards = initDeck;
        }
    }
}
