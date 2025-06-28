using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door;
    public Vector3 openOffset = new Vector3(0f, 3f, 0f);
    public float moveSpeed = 2f;

    private Vector3 doorClosedPosition;
    private Vector3 doorOpenPosition;

    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        if (door == null) door = transform;

        doorClosedPosition = door.position;
        doorOpenPosition = doorClosedPosition + openOffset;
        targetPosition = doorClosedPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            door.position = Vector3.MoveTowards(door.position, targetPosition, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(door.position, targetPosition) < 0.01f)
            {
                door.position = targetPosition;
                isMoving = false;
            }
        }
    }

    // ----- Open Door -----
    public void OpenDoor()
    {
        targetPosition = doorOpenPosition;
        isMoving = true;

        DelegatesData.ShowFeedbackWithColorIndex(door.transform.position, 2, "Open");
        SoundManager.Instance?.PlaySound(SoundManager.Instance.LeverDoorOpen);
    }

    // ----- Close Door -----
    public void CloseDoor()
    {
        targetPosition = doorClosedPosition;
        isMoving = true;
        DelegatesData.ShowFeedbackWithColorIndex(door.transform.position, 2, "Close");
        SoundManager.Instance?.PlaySound(SoundManager.Instance.LeverDoorOpen);
    }


    public bool IsFullyOpened => Vector3.Distance(door.position, doorOpenPosition) < 0.01f;
    public bool IsFullyClosed => Vector3.Distance(door.position, doorClosedPosition) < 0.01f;
}
