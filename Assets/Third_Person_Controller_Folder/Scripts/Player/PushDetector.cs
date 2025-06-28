using UnityEngine;

public class PushDetector : MonoBehaviour
{
    public bool isTouchingPushable { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            isTouchingPushable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushable"))
        {
            isTouchingPushable = false;
        }
    }
}