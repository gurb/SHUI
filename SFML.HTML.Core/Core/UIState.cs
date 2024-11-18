namespace SFML.HTML.Core.Core
{
    public class UIState
    {
        public string StateName { get; set; } = string.Empty;
        public string HTML { get; set;} = string.Empty;
        public string CSS { get; set;} = string.Empty;

        public async Task ReadFile(string PathFile)
        {
            try
            {
                string replacePath = PathFile.Replace("/", "\\");
                string path = Path.Combine(Directory.GetCurrentDirectory(), replacePath);
                using StreamReader reader = new(path);
                string extension = Path.GetExtension(PathFile);
                if(extension == ".css")
                {
                    CSS = await reader.ReadToEndAsync();
                    await UIParse.CSSParser(CSS);
                }
                else if(extension == ".html")
                {
                    HTML = await reader.ReadToEndAsync();
                    await UIParse.HTMLParser(HTML);
                }
            }
            catch 
            {
                
            }   
        }
    }
}
