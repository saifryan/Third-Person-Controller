using UnityEngine;
using TMPro;

public class AlertPopup : Popup
{
    [Header("----- Text -----")]
    [SerializeField] TextMeshProUGUI TitleText;
    [SerializeField] TextMeshProUGUI DescriptionText;
    [SerializeField] GameObject CloseButton;


    // Set Data Popup
    public void SetData(string title, string description, bool closeButtonStatus)
    {
        // Title
        TitleText.text = title;
        // Description
        DescriptionText.text = description;
        CloseButton.SetActive(closeButtonStatus);
        BGImagestatus();
    }

    void BGImagestatus()
    {
        StartCoroutine(AnimationEffect.FadeImage(BgPanel, 0f, 0.85f, 0, 0.35f));
    }

    // Functions

    public void GoToHome()
    {
        PopupController.LoadScene("MainMenu");
    }


    public void GoToRetry()
    {
        PopupController.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ClosePanel()
    {
        PopupController.AnyPanelOpen = false;
        Close();
    }
}