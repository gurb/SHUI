using SFML.Graphics;
using SFML.HTML.Core.DTO;

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
        public static async Task Initialize(SHUIConfig config)
        {
            await InitializeStates(config.States);

            renderTexture = new RenderTexture(config.Width, config.Height);
            surface = new Sprite();
            surface.TextureRect = new IntRect(0, 0, (int)config.Width, (int)config.Height);
            surface.Texture = renderTexture.Texture;
        }

        private static async Task InitializeStates(List<SHUIState> states)
        {
            UIStates = new Dictionary<string, UIState>();

            foreach (var state in states) 
            {
                var uiState = new UIState();
                uiState.StateName = state.StateName;
                await uiState.ReadFile(state.HTML);
                await uiState.ReadFile(state.CSS);

                UIStates.Add(state.StateName, uiState);
            }
        }

        public static void SetUIState(string uiState)
        {
            if (uiState == string.Empty) return;

            if(UIStates!.ContainsKey(uiState))
            {
                ActiveUIState = UIStates[uiState];
            }
        }

        public static void Update()
        {
            if (ActiveUIState is null)
            {
                return;
            }
        }

        public static void Draw(RenderWindow window)
        {
            if (ActiveUIState is null)
            {
                return;
            }

            renderTexture!.Clear(SFML.Graphics.Color.White);
            renderTexture.Display();
            window.Draw(surface);
        }
    }
}
