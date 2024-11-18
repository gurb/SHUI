using SFML.Graphics;
using SFML.HTML.Core.DTO;
using SFML.System;
using System.Security.Cryptography.X509Certificates;

namespace SFML.HTML.Core.Core
{
    /// <summary>
    /// ui main class
    /// </summary>
    public static class SHUI
    {
        static RenderTexture? renderTexture;
        static Sprite? surface;
        static Dictionary<string, UIState>? UIStates;
        static UIState? ActiveUIState;

        /// <summary>
        /// Initiliaze all html elements
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static async Task Initialize(SHUIConfig config)
        {
            await InitializeStates(config.States);

            renderTexture = new RenderTexture(config.Width, config.Height);
            surface = new Sprite();
            surface.TextureRect = new IntRect(0, 0, (int)config.Width, (int)config.Height);
            surface.Texture = renderTexture.Texture;
        }

        /// <summary>
        /// initialize states
        /// </summary>
        /// <param name="states"></param>
        /// <returns></returns>
        private static async Task InitializeStates(List<SHUIState> states)
        {
            UIStates = new Dictionary<string, UIState>();

            foreach (var state in states) 
            {
                var uiState = new UIState();
                uiState.StateName = state.StateName!;
                await uiState.ReadFile(state.HTML!, state.CSS!);

                UIStates.Add(state.StateName!, uiState);
            }
        }

        /// <summary>
        /// change active ui state. The ui state can be thought of as a page.
        /// </summary>
        /// <param name="uiState">enter the ui state name to make active</param>
        public static void SetUIState(string uiState)
        {
            if (uiState == string.Empty) return;

            if(UIStates!.ContainsKey(uiState))
            {
                ActiveUIState = UIStates[uiState];
            }
        }

        /// <summary>
        /// get active ui state.
        /// </summary>
        /// <returns></returns>
        public static UIState? GetActiveUIState()
        {
            return ActiveUIState;
        }

        /// <summary>
        /// get ui size
        /// </summary>
        /// <returns>Vector2U(uint x, uint y)</returns>
        public static Vector2u GetUIBounds()
        {
            return renderTexture!.Size;
        }

        /// <summary>
        /// update the active ui state. handle inputs.
        /// </summary>
        public static void Update()
        {
            if (ActiveUIState is null)
            {
                return;
            }

        }

        /// <summary>
        /// draw ui to sfml window
        /// </summary>
        /// <param name="window">sfml main window instance</param>
        public static void Draw(RenderWindow window)
        {
            if (ActiveUIState is null)
            {
                return;
            }

            renderTexture!.Clear(SFML.Graphics.Color.White);
            UIRender.Render(renderTexture);
            renderTexture.Display();

            window.Draw(surface);
        }
    }
}
