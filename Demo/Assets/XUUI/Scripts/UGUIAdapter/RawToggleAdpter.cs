using UnityEngine.UI;
using System;

namespace XUUI.UGUIAdapter
{
    public class RawToggleAdapter : RawAdapterBase, DataConsumer<bool>, DataProducer<bool>
    {
        private Toggle target;

        public Action<bool> OnValueChange { get; set; }

        public bool Value
        {
            set
            {
                target.isOn = value;
            }
        }

        public RawToggleAdapter(Toggle toggle, string bindTo)
        {
            target = toggle;
            BindTo = bindTo;

            target.onValueChanged.AddListener((val) =>
            {
                if (OnValueChange != null)
                {
                    OnValueChange(val);
                }
            });
        }
    }
}
