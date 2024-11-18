namespace SFML.HTML.Core.Core
{
    public static class UIConverter
    {
        public static SFML.Graphics.Color ConvertCSSColortoSFMLColor(string color)
        {
            switch (color)
            {
                case "white":
                    return SFML.Graphics.Color.White;
                case "black":
                    return SFML.Graphics.Color.Black;
                default:
                    return SFML.Graphics.Color.White;
            }
        }

    }
}
