using UnityEngine;

namespace XUUI
{
    public class AdapterBase : MonoBehaviour
    {
        [TextArea]
        public string BindTo;
    }

    public class AdapterBase<T> : AdapterBase
    {
        public T Target;

        void Awake()
        {
            //if (Target == null)
            //{
            //    Target = gameObject.GetComponent<T>();
            //}
        }

        // 添加脚本默认赋值
        void Reset()
        {
            if (Target == null)
            {
                Target = gameObject.GetComponent<T>();
            }
        }
    }
}
