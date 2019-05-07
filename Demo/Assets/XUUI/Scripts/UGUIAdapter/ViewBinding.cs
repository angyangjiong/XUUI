using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace XUUI.UGUIAdapter
{
    public enum ComponentType
    {
        Text,
        InputField,
        Button,
        Dropdown,
        Slider,
        Toggle,
        Image
    }

    [Serializable]
    public struct Binding
    {
        [SerializeField]
        public ComponentType Type;

        [SerializeField]
        public Component Component;

        [SerializeField]
        public string BindTo;

        [SerializeField]
        public bool MultiFields;
    }

    public class ViewBinding : MonoBehaviour
    {
        private void Start()
        {
            
        }

        [HideInInspector]
        [SerializeField]
        public List<Binding> Bindings;

        [NonSerialized]
        private object[][] cacheAdapters = null;

        private RawAdapterBase createAdapter(Component component, string bindTo)
        {
            if (component is Text)
            {
                Text text = component as Text;
                if (text != null)
                {
                    return new RawTextAdapter(text, bindTo);
                }
            }
            else if (component is Button)
            {
                Button button = component as Button;
                if (button != null)
                {
                    return new RawButtonAdapter(button, bindTo);
                }
            }
            else if (component is InputField)
            {
                InputField inputField = component as InputField;
                if (inputField != null)
                {
                    return new RawInputFieldAdapter(inputField, bindTo);
                }
            }
            else if (component is Dropdown)
            {
                Dropdown dropdown = component as Dropdown;
                if (dropdown != null)
                {
                    return new RawDropdownAdapter(dropdown, bindTo);
                }
            }
            else if (component is Slider)
            {
                Slider slider = component as Slider;
                if (slider != null)
                {
                    return new RawSliderAdapter(slider, bindTo);
                }
            }
            else if (component is Toggle)
            {
                Toggle toggle = component as Toggle;
                if (toggle != null)
                {
                    return new RawToggleAdapter(toggle, bindTo);
                }
            }
            else if (component is Image)
            {
                Image image = component as Image;
                if (image != null)
                {
                    return new RawImageAdapter(image, bindTo);
                }
            }

            return null;
        }

        public object[][] GetAdapters()
        {
            if (cacheAdapters == null)
            {
                if (Bindings == null || Bindings.Count == 0)
                {
                    cacheAdapters = new object[][] { };
                }
                else
                {
                    var dataConsumers = new List<object>();
                    var dataProducers = new List<object>();
                    var eventEmitters = new List<object>();

                    for (int i = 0; i < Bindings.Count; i++)
                    {
                        var binding = Bindings[i];
                        RawAdapterBase adapter = createAdapter(binding.Component, binding.BindTo);
                        if (adapter == null)
                        {
                            throw new InvalidOperationException("no adatper for " + binding.Component);
                        }
                        if (adapter is DataConsumer)
                        {
                            dataConsumers.Add(adapter);
                        }
                        if (adapter is DataProducer)
                        {
                            dataProducers.Add(adapter);
                        }
                        if (adapter is EventEmitter)
                        {
                            eventEmitters.Add(adapter);
                        }
                    }

                    cacheAdapters = new object[][] { dataConsumers.ToArray(), dataProducers.ToArray(), eventEmitters.ToArray() };
                }
            }
            return cacheAdapters;
        }

    }
}
