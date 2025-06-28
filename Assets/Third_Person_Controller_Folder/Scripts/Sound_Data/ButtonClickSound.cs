using UnityEngine;

namespace Falcon.Code.Sound
{
    public class ButtonClickSound : MonoBehaviour
    {
        public void ButtonClick()
        {
            SoundManager.Instance?.PlaySound(SoundManager.Instance.ButtonClick);
        }
    }
}