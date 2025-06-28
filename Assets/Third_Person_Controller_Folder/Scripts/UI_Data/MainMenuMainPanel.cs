using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMainPanel : MonoBehaviour
{
    [SerializeField] GameObject ShowCaseButton;
    [SerializeField] GameObject LevelButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationEffect.ScaleOutBack(ShowCaseButton.transform, Vector3.zero, Vector3.one, 0.5f, 0.35f));
        StartCoroutine(AnimationEffect.ScaleOutBack(LevelButton.transform, Vector3.zero, Vector3.one, 0.5f, 0.35f));
    }

    public void ShowCaseSceneOpen()
    {
        PopupController.LoadScene("ShowCase");
    }

    public void LevelPanelOpen()
    {
        PopupController.LoadScene("GamePlay");
    }
}