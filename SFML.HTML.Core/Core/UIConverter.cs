using SFML.HTML.Core.UI.Enums;

namespace SFML.HTML.Core.Core
{
    public static class UIConverter
    {
        static Dictionary<string, PropertyType> PropertyTypes = new Dictionary<string, PropertyType>
        {
            { "background", PropertyType.Background },
            { "background-color", PropertyType.Background },
            { "color", PropertyType.Color },
            { "font-size", PropertyType.FontSize }
        };

        public static SFML.Graphics.Color ConvertCSSColortoSFMLColor(string color)
        {
            string values = color.Substring(5, color.Length - 6);
            var components = values.Split(',');

            byte r = byte.Parse(components[0].Trim());
            byte g = byte.Parse(components[1].Trim());
            byte b = byte.Parse(components[2].Trim());
            byte a = (byte)(float.Parse(components[3].Trim()) * 255);

            SFML.Graphics.Color sfmlColor = new SFML.Graphics.Color(r, g, b, a);
            return sfmlColor;
        }

        public static PropertyType? ConvertCSSPropertyNameToProperyType(string propertyName)
        {
            if(PropertyTypes.ContainsKey(propertyName))
            {
                return PropertyTypes[propertyName];
            }

            return null;
        }

    }
}
