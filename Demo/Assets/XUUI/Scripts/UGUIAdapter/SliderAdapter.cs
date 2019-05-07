using UnityEngine;
using UnityEngine.UI;
using System;

namespace XUUI.UGUIAdapter
{
    [AddComponentMenu("XUUI/Slider", 1)]
    [RequireComponent(typeof(Slider))]
    public class SliderAdapter : AdapterBase<Slider>, DataConsumer<float>, DataProducer<float>
    {
        public Action<float> OnValueChange { get; set; }

        public float Value
        {
            set
            {
                Target.value = value;
            }
        }

        void Start()
        {
            Target.onValueChanged.AddListener((val) =>
            {
                OnValueChange?.Invoke(val);
            });
        }
    }
}
