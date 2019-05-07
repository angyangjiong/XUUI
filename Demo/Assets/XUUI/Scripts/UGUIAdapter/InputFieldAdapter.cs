using UnityEngine;
using UnityEngine.UI;
using System;

namespace XUUI.UGUIAdapter
{
    [AddComponentMenu("XUUI/InputField", 1)]
    [RequireComponent(typeof(InputField))]
    public class InputFieldAdapter : AdapterBase<InputField>, DataConsumer<string>, DataProducer<string>
    {

        public Action<string> OnValueChange { get; set; } // InputField发生变化需要调用OnValueChange

        public string Value // VM发生变化，会调用到该Setter，需要同步给InputField
        {
            set
            {
                Target.text = value ?? "";
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
