using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform doorPivot;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 2f;
    [SerializeField] private bool autoDoor = true;

    [SerializeField] GameObject CloseTrigger;

    private Quaternion closedRotation;
    private Quaternion targetRotation;
    private bool isOpen = false;

    private void Start()
    {
        closedRotation = doorPivot.localRotation;
        targetRotation = closedRotation;
        CloseTrigger.SetActive(autoDoor);
    }

    private void Update()
    {
        doorPivot.localRotation = Quaternion.Lerp(doorPivot.localRotation, targetRotation, Time.deltaTime * openSpeed);
    }

    public void Interact(Transform interactor)
    {
        if (!isOpen)
        {
            OpenDoor(interactor);
        }
        else
        {
            CloseDoor();
        }
    }

    // ----- Open Door Area -----
    private void OpenDoor(Transform interactor)
    {
        isOpen = true;
        Vector3 doorForward = doorPivot.forward;
        Vector3 toPlayer = (interactor.position - doorPivot.position).normalized;
        float dot = Vector3.Dot(doorForward, toPlayer);
        float direction = dot >= 0 ? -1f : 1f;
        targetRotation = Quaternion.Euler(0, direction * openAngle, 0) * closedRotation;
        DelegatesData.ShowFeedbackWithColorIndex(transform.position, 2, "Open");
        SoundManager.Instance?.PlaySound(SoundManager.Instance.DoorOpen);
    }

    public void AutoDoorOpen(Transform interactor)
    {
        if (autoDoor && !isOpen)
        {
            isOpen = true;
            Vector3 localPos = doorPivot.InverseTransformPoint(interactor.position);
            float direction = localPos.z >= 0f ? 1f : -1f;
            targetRotation = Quaternion.Euler(0, direction * openAngle, 0) * closedRotation;

            SoundManager.Instance?.PlaySound(SoundManager.Instance.DoorOpen);
        }
    }

    // ----- Close Door Area -----
    private void CloseDoor()
    {
        isOpen = false;
        targetRotation = closedRotation;
        if (!autoDoor)
            DelegatesData.ShowFeedbackWithColorIndex(transform.position, 2, "Close");

        SoundManager.Instance?.PlaySound(SoundManager.Instance.DoorClose);
    }

    public void AutoDoorClose()
    {
        if (autoDoor && isOpen)
        {
            CloseDoor();
        }
    }
}
