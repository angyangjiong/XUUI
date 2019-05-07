using UnityEngine;
using UnityEngine.UI;

namespace XUUI.UGUIAdapter
{
    [AddComponentMenu("XUUI/Text", 1)]
    [RequireComponent(typeof(Text))]
    public class TextAdapter : AdapterBase<Text>, DataConsumer<string>
    {

        void Start()
        {

        }

        public string Value
        {
            set
            {
                Target.text = value;
            }
        }
    }
}
