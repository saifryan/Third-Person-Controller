using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected || !other.CompareTag("Player"))
            return;

        isCollected = true;
        PopupController.AlertPanelOpen("Lose", "You lose! \n Try Again!", 4, false);
        SoundManager.Instance?.PlaySound(SoundManager.Instance.LoseSound);
    }
}
