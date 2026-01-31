namespace WinFormsApp1.enums
{
    public static class EnumExtentions
    {
        public static String GetDisplayName(this RoundModifierEnum value)
        {
            switch (value)
            {

                case RoundModifierEnum.LightDoubleValue:
                    return "Light Double Value";
                case RoundModifierEnum.DarkDoubleValue:
                    return "Dark Double Value";
                case RoundModifierEnum.LockedHandCard:
                    return "Locked Hand Card";
                case RoundModifierEnum.PeekFirstCard:
                    return "Peek First Deck Card";
                case RoundModifierEnum.EnergyDebuff:
                    return "Energy Debuff";
                case RoundModifierEnum.AltarLock:
                    return "Altar Locked";
                default:
                    return "";
            }
        }
    }
}
