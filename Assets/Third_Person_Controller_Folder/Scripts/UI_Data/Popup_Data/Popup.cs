using UnityEngine;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
    public UnityEvent onOpen;
    public UnityEvent onClose;
    [Header("----- BG -----")]
    public UnityEngine.UI.Image BgPanel;

    public virtual void Awake()
    {
    }

    public virtual void Start()
    {
        onOpen.Invoke();
    }

    public void Close()
    {
        onClose.Invoke();
        Destroy(gameObject);
    }
}