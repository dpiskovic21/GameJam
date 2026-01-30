using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using WinFormsApp1.enums;

namespace WinFormsApp1.models
{
    public static class Deck
    {
        public static List<Card> Cards { get; set; } = new List<Card>(60);
        public static List<Card> ShuffledDeck { get; set; } = new List<Card>(60);

        public static void InitializeDeck()
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
            Deck.ShuffleDeck();
            List<Card> shuffledCards = Deck.ShuffledDeck;

            Console.WriteLine("bok");
        }

        public static void ShuffleDeck()
        {
            ShuffledDeck.Clear();

            List<Card> cardsBeforeShuffle = new List<Card>(Cards);
            Random random = new Random();

            while (cardsBeforeShuffle.Count > 0)
            {
                int index = random.Next(cardsBeforeShuffle.Count);

                ShuffledDeck.Add(cardsBeforeShuffle[index]);
                cardsBeforeShuffle.RemoveAt(index);
            }
        }

    }
}
