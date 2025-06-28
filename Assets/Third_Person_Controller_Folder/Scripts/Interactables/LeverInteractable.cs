using UnityEngine;

public class LeverInteractable : MonoBehaviour, IInteractable
{
    public Transform leverHandle;
    public Vector3 startValue = Vector3.zero;
    public Vector3 endValue = new Vector3(45f, 0f, 0f);
    public float rotationSpeed = 5f;

    private bool isAnimating = false;
    private Quaternion targetRotation;
    private bool isOn = false;

    public DoorController connectedDoor;

    private void Start()
    {
        if (leverHandle == null) leverHandle = transform;
        leverHandle.localRotation = Quaternion.Euler(startValue);
    }

    private void Update()
    {
        if (isAnimating)
        {
            leverHandle.localRotation = Quaternion.Lerp(leverHandle.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Quaternion.Angle(leverHandle.localRotation, targetRotation) < 0.1f)
            {
                leverHandle.localRotation = targetRotation;
                isAnimating = false;
            }
        }
    }

    public void Interact(Transform interactor)
    {
        if (isAnimating) return;

        isOn = !isOn;
        targetRotation = Quaternion.Euler(isOn ? endValue : startValue);
        isAnimating = true;
        SoundManager.Instance?.PlaySound(SoundManager.Instance.LeverPull);
        if (connectedDoor != null)
        {
            if (isOn && !connectedDoor.IsFullyOpened)
            {
                connectedDoor.OpenDoor();
            }
            else if (!isOn && !connectedDoor.IsFullyClosed)
            {
                connectedDoor.CloseDoor();
            }
        }
    }
}