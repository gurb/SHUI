using AngleSharp;
using AngleSharp.Css.Parser;
using AngleSharp.Dom;
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
                var style = body.ComputeCurrentStyle();
                foreach (var property in style)
                {
                    Console.WriteLine($"{property.Name}: {property.Value}");
                }
                elements.Add(new BaseHtmlElement
                {
                    ElementType = UI.Enums.ElementType.BODY,
                });
            }
            //var titles = document.QuerySelectorAll("h1");

            return elements;
        }


        public static async Task CSSParser(string cssContent)
        {
            var parser = new CssParser();

            var stylesheet = await parser.ParseStyleSheetAsync(cssContent);

        }
    }
}
