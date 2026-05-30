using UnityEngine;
using UnityEngine.Events;

public class MouseEvents : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnEnter { get; private set; }
    [field: SerializeField]
    public UnityEvent OnExit { get; private set; }
    [field: SerializeField]
    public UnityEvent OnClick { get; private set; }

    // This will only fire if when the mouse enters
    // the attached TriggerCollider
    void OnMouseEnter()
    {
        transform.parent.gameObject.name = "MouseEntered";
        OnEnter.Invoke();
    }

    void OnMouseExit()
    {
        transform.parent.gameObject.name = "Exited";
        OnExit.Invoke();
    }

    void OnMouseUpAsButton()
    {
        transform.parent.gameObject.SetActive(false);
        OnClick.Invoke();
    }
}
