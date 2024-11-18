using SFML.Graphics;
using SFML.HTML.Core.Core;
using SFML.HTML.Core.UI.Enums;
using SFML.System;
using System.Numerics;

namespace SFML.HTML.Core.UI.Models.Elements
{
    public class BodyElement: BaseHtmlElement
    {
        public BodyElement(): base(ElementType.BODY)
        {

        }

        public override void SetDefaultProperties()
        {
            CssProperties = new()
            {
                { PropertType.Background, "white" }
            };

            base.SetDefaultProperties();
        }

        public override void SetDefaultRender()
        {
            Sprite = new Sprite();
            Vector2u size = SHUI.GetUIBounds();
            RenderTexture = new RenderTexture(size.X, size.Y);
            RenderTexture.Clear();
            RenderTexture.Display();
            Sprite.Position = new Vector2f(0, 0);
            Sprite.Texture = RenderTexture.Texture;
        }
    }
}
