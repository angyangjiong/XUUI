using UnityEngine;
using UnityEngine.UI;

namespace XUUI.UGUIAdapter
{
    public class RawImageAdapter : RawAdapterBase, DataConsumer<Texture2D>
    {
        private Image target;

        public Texture2D Value
        {
            set
            {
                target.SetSprite(value);
            }
        }

        public RawImageAdapter(Image image, string bindTo)
        {
            target = image;
            BindTo = bindTo;
        }
    }
}
