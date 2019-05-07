using UnityEngine;
using UnityEngine.UI;
using System;

namespace XUUI.UGUIAdapter
{
    [AddComponentMenu("XUUI/Toggle", 1)]
    [RequireComponent(typeof(Toggle))]
    public class ToggleAdapter : AdapterBase<Toggle>, DataConsumer<bool>, DataProducer<bool>
    {
        public Action<bool> OnValueChange { get; set; }

        public bool Value
        {
            set
            {
                Target.isOn = value;
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
