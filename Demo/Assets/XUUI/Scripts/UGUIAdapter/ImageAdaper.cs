using UnityEngine;
using UnityEngine.UI;

namespace XUUI.UGUIAdapter
{
    [AddComponentMenu("XUUI/Image", 1)]
    [RequireComponent(typeof(Image))]
    public class ImageAdaper : AdapterBase<Image>, DataConsumer<Texture2D>
    {
        public Texture2D Value
        {
            set
            {
                Target.SetSprite(value);
            }
        }

        void Start()
        {
        }
    }
}
