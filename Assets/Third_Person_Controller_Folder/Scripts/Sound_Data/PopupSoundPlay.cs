using UnityEngine;

namespace Falcon.Code.Sound
{
    public class PopupSoundPlay : MonoBehaviour
    {
        // Popup Open
        public void PopupOpen()
        {
            SoundManager.Instance?.PlaySound(SoundManager.Instance.PopupOpen);
        }

        // Popup Close
        public void PopupClose()
        {
            SoundManager.Instance?.PlaySound(SoundManager.Instance.PopupClose);
        }
    }
}