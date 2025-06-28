using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected || !other.CompareTag("Player"))
            return;

        isCollected = true;
        PopupController.AlertPanelOpen("Win", "You Complete this level.", 4, false);
        SoundManager.Instance?.PlaySound(SoundManager.Instance.WinSound);
    }
}
