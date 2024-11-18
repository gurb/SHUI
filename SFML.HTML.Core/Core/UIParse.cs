using AngleSharp;
using AngleSharp.Css.Parser;
using AngleSharp.Dom;
using SFML.Graphics;
using SFML.HTML.Core.UI.Enums;
using SFML.HTML.Core.UI.Models.Elements;

namespace SFML.HTML.Core.Core
{
    public static class UIParse
    {
        public static async Task HTMLParser(string htmlContent)
        {
            
        }

        public static async Task<List<BaseHtmlElement>> GetHtmlElements(string htmlContent, string cssContent)
        {
            List<BaseHtmlElement> elements = new List<BaseHtmlElement>();

            var config = Configuration.Default.WithCss();
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(req => req.Content(htmlContent));
            
            var styleElement = document.CreateElement("style");
            styleElement.TextContent = cssContent;
            document.Head!.AppendChild(styleElement);

            var body = document.QuerySelector("body");
            
            if (body != null)
            {
                BodyElement element = new BodyElement();
                SetCssProperties(element, body);
                elements.Add(element);
            }
            //var titles = document.QuerySelectorAll("h1");

            return elements;
        }


        public static async Task CSSParser(string cssContent)
        {
            var parser = new CssParser();

            var stylesheet = await parser.ParseStyleSheetAsync(cssContent);

        }

        private static void SetCssProperties(BaseHtmlElement element, IElement? htmlElement)
        {
            var style = htmlElement.ComputeCurrentStyle();
            foreach (var property in style)
            {
                PropertyType? type = UIConverter.ConvertCSSPropertyNameToProperyType(property.Name);

                if (type is not null)
                {
                    if (element.CssProperties.ContainsKey(type.Value))
                    {
                        element.CssProperties[type.Value] = property.Value.ToString();
                    }
                    else
                    {
                        element.CssProperties.Add(type.Value, property.Value.ToString());
                    }

                    SetProperty(element, type.Value);
                }

                Console.WriteLine($"{property.Name}: {property.Value}");
            }
        }

        private static void SetProperty(BaseHtmlElement element, PropertyType type)
        {
            switch (type)
            {
                case PropertyType.Background:
                    SetBackgroundProperty(element);
                    break;
                default:
                    break;
            }
        }

        private static void SetBackgroundProperty(BaseHtmlElement element)
        {
            var test = element.GetCssPropertyValue(PropertyType.Background)!;
            Color color = UIConverter.ConvertCSSColortoSFMLColor(test);
            element.RenderTexture!.Clear(color);
            element.RenderTexture!.Display();
        }
    }
}
