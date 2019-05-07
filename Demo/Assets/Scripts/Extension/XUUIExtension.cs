using UnityEngine;
using XUUI;

public class XUUIExtension : MonoBehaviour
{
    Context context = null;

    public TextAsset _script;

    void Start()
    {
        context = new Context(_script.text);

        context.Attach(gameObject);
    }

    void OnDestroy()
    {
        context.Dispose();
    }
}
