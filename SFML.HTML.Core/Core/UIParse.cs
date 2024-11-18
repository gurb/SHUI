using AngleSharp;
using AngleSharp.Css.Parser;

namespace SFML.HTML.Core.Core
{
    public static class UIParse
    {
        public static async Task HTMLParser(string htmlContent)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(req => req.Content(htmlContent));
            var titles = document.QuerySelectorAll("h1");
        }

        public static async Task CSSParser(string cssContent)
        {
            var parser = new CssParser();

            var stylesheet = await parser.ParseStyleSheetAsync(cssContent);

            // Örnek: Tüm CSS kurallarını yazdır
            foreach (var rule in stylesheet.Rules)
            {
                Console.WriteLine(rule.CssText);
            }
        }
    }
}
