using WinFormsApp1.enums;

namespace WinFormsApp1.models
{
    public static class Deck
    {
        private static Dictionary<string, Bitmap> _loadedImages = new();
        public readonly static Bitmap CardBackImage = ResizeCardImage("..\\..\\..\\resources\\card-back.jpg", 320, 220);
        public readonly static Bitmap CardPlaceholderImage = ResizeCardImage("..\\..\\..\\resources\\placeholder.jpg", 320, 220);

        public static List<Card> Cards { get; set; } = new List<Card>(60);
        public static List<Card> ShuffledDeck { get; set; } = new List<Card>(60);

        public static int CardHeight { get; set; }
        public static int CardWidth { get; set; }

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

                    Card card = new Card();

                    card.CardImage = ResizeCardImage($"..\\..\\..\\resources\\{j}.png", 320, 220);

                    card.Value = j;
                    card.CardTypeEnum = cardType;

                    initDeck.Add(card);
                }
            }

            Deck.Cards = initDeck;
            Deck.ShuffleDeck();
            List<Card> shuffledCards = Deck.ShuffledDeck;
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


        public static Bitmap ResizeCardImage(String path, int height, int width)
        {
            Bitmap original;
            if (!_loadedImages.ContainsKey(path))
            {
                _loadedImages[path] = new Bitmap(path);
            }
            original = _loadedImages[path];
            var resized = new Bitmap(width, height);

            using (var g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, width, height);
            }

            return resized;
        }

    }
}
