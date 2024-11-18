using SFML.Graphics;
using SFML.HTML.Core.UI.Enums;
using SFML.HTML.Core.UI.Models.Common;

namespace SFML.HTML.Core.UI.Models.Elements
{
    public class BaseHtmlElement
    {
        public ElementType ElementType { get; set; } = ElementType.HTML;
        public Dictionary<PropertType, string> CssProperties { get; set; } = new Dictionary<PropertType, string>();
        public List<BaseHtmlElement>? Children { get; set; } = new List<BaseHtmlElement>();
        public BaseHtmlElement? Parent { get; set; }

        public Sprite? Sprite { get; set; }
        public RenderTexture? RenderTexture { get; set; }

        public BaseHtmlElement()
        {
            this.SetDefaultProperties();
            this.SetDefaultRender();
        }

        public BaseHtmlElement(ElementType elementType)
        {
            this.ElementType = elementType;
            this.SetDefaultProperties();
            this.SetDefaultRender();
        }

        public virtual void SetDefaultRender()
        {
            RenderTexture = new RenderTexture(1, 1);
            Sprite = new Sprite();
            Sprite.Texture = RenderTexture.Texture;

            // override this
        }

        public virtual void SetDefaultProperties()
        {
            // override this
        }

        public string? GetCssPropertyValue(PropertType type)
        {
            if(CssProperties.ContainsKey(type))
            {
                return CssProperties[type];
            }
            return null;
        }
    }
}
