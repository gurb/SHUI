using SFML.HTML.Core.UI.Models.Elements;
using SFML.System;

namespace SFML.HTML.Core.Core
{
    public class UIState
    {
        public string StateName { get; set; } = string.Empty;
        public string HTML { get; set;} = string.Empty;
        public string CSS { get; set;} = string.Empty;
        public List<BaseHtmlElement>? Elements { get; set; }

        public Vector2u? Size { get; set; }

        public UIState()
        {
            
        }

        public async Task ReadFile(string htmlPathFile, string cssPathFile)
        {
            try
            {
                htmlPathFile = htmlPathFile.Replace("/", "\\");
                cssPathFile = cssPathFile.Replace("/", "\\");
                string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), htmlPathFile);
                string cssPath = Path.Combine(Directory.GetCurrentDirectory(), cssPathFile);
                using StreamReader readerHtml = new(htmlPath);
                using StreamReader readerCss = new(cssPath);
                
                HTML = await readerHtml.ReadToEndAsync();
                CSS = await readerCss.ReadToEndAsync();
                Elements = await UIParse.GetHtmlElements(HTML, CSS);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
    }
}
