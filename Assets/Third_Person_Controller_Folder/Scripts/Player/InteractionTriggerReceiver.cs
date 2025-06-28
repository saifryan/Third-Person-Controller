using UnityEngine;

public class InteractionTriggerReceiver : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
            DelegatesData.PressEObjectStatus(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && interactable == currentInteractable)
        {
            currentInteractable = null;
            DelegatesData.PressEObjectStatus(false);
        }
    }

    private void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact(transform);
        }
    }
}
