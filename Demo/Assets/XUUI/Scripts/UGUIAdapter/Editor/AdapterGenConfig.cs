using System.Collections.Generic;
using System;
using XLua;
using UnityEngine.UI;
using UnityEngine;

namespace XUUI.UGUIAdapter
{
    public static class AdapterGenConfig
    {
        [LuaCallCSharp]
        public static List<Type> LuaCallCSharp = new List<Type>()
        {
            typeof(TextAdapter),
            typeof(InputFieldAdapter),
            typeof(DropdownAdapter),
            typeof(ButtonAdapter),
            typeof(DropdownOptionsAdapter),
            typeof(AdapterBase),
            typeof(RawAdapterBase),
            typeof(RawTextAdapter),
            typeof(RawInputFieldAdapter),
            typeof(RawDropdownAdapter),
            typeof(RawButtonAdapter),
            typeof(SliderAdapter),
            typeof(RawSliderAdapter),
            typeof(ToggleAdapter),
            typeof(RawToggleAdapter),
            typeof(Texture2D),
            typeof(ImageAdaper),
            typeof(RawImageAdapter),
        };

        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>()
        {
            typeof(Action),
            typeof(Action<string>),
            typeof(Action<int>),
            typeof(Action<float>),
            typeof(Action<bool>),
            typeof(Action<Texture2D>),
        };
    }
}