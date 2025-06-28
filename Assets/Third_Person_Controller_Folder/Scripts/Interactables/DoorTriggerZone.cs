using UnityEngine;

public class DoorTriggerZone : MonoBehaviour
{
    [SerializeField] private DoorInteractable door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.AutoDoorOpen(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.AutoDoorClose();
        }
    }
}