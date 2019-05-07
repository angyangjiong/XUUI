using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace XUUI.UGUIAdapter
{
    public static class XUUIHelper
    {
        public static void SetSprite(this Image image, Texture2D texture2D)
        {
            if (image.sprite != null)
            {
                Object.Destroy(image.sprite);
            }
            var sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
            image.sprite = sprite;
        }
    }
}
