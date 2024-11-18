using SFML.Graphics;
using SFML.HTML.Core.UI.Models.Elements;

namespace SFML.HTML.Core.Core
{
    /// <summary>
    /// Render all html elements right here
    /// </summary>
    public static class UIRender
    {
        private static RenderTexture? uiDisplay;
        /// <summary>
        /// main ui render method
        /// </summary>
        /// <param name="display">ui renderTexture for display</param>
        public static void Render(RenderTexture display)
        {
            uiDisplay = display;
            UIState? activeState = SHUI.GetActiveUIState();
            if (activeState == null) return;

            foreach (var element in activeState.Elements!) 
            {
                DrawElement(element);
            }
        }

        /// <summary>
        /// draw element
        /// </summary>
        /// <param name="element">an html element</param>
        private static void DrawElement(BaseHtmlElement element)
        {
            uiDisplay!.Draw(element.Sprite);
        }

    }
}
