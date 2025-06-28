using UnityEngine;

public class FootStep : MonoBehaviour
{
    // Foot Stop Sound Play
    public void FootStopSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.FootStep);
    }

    // Jump Start Sound Play
    public void JumpStartSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.JumpStart);
    }

    // Jump End Sound Play
    public void JumpEndSoundPlay()
    {
        if (PopupController.AnyPanelOpen) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.JumpLand);
    }
}