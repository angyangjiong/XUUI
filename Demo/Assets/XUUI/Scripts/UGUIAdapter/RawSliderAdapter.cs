using UnityEngine.UI;
using System;

namespace XUUI.UGUIAdapter
{
    public class RawSliderAdapter : RawAdapterBase, DataConsumer<float>, DataProducer<float>
    {
        private Slider target;

        public Action<float> OnValueChange { get; set; }

        public float Value
        {
            set
            {
                target.value = value;
            }
        }

        public RawSliderAdapter(Slider slider, string bindTo)
        {
            target = slider;
            BindTo = bindTo;

            target.onValueChanged.AddListener((val) =>
            {
                OnValueChange?.Invoke(val);
            });
        }
    }
}
