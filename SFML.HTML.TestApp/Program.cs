using SFML.Graphics;
using SFML.HTML.Core.Core;
using SFML.Window;

namespace SFML.HTML.TestApp;

class Program
{
    static async Task Main(string[] args)
    {
        const int WIDTH = 640;
        const int HEIGHT = 480;
        const string TITLE = "SFML.HTML.TestApp";
        RenderWindow? window;
        VideoMode mode = new VideoMode(WIDTH, HEIGHT);

        await SHUI.Initialize(new Core.DTO.SHUIConfig
        {
            Width = WIDTH,
            Height = HEIGHT,
            States = new List<Core.DTO.SHUIState>
            {
                new Core.DTO.SHUIState { StateName = "Base", CSS = "UI/Base/Base.css", HTML = "UI/Base/Base.html", } 
            }
        });

        window = new RenderWindow(mode, TITLE);
        window.SetVerticalSyncEnabled(true);
        window.SetFramerateLimit(60);

        while (window.IsOpen)
        {
            SHUI.SetUIState(string.Empty);
            // handle events
            window.DispatchEvents();
            SHUI.Update();
            // update

            window.Clear(Color.Blue);
            // draw
            
            SHUI.Draw(window);
            window.Display();
        }
    }
}
