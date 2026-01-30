using WinFormsApp1.enums;

namespace WinFormsApp1.models
{
    public class Card
    {
        public int Value { get; set; }
        public Bitmap CardImage { get; set; }
        public CardTypeEnum CardTypeEnum { get; set; }
    }
}
