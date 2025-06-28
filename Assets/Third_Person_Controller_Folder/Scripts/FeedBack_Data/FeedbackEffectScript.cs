using UnityEngine;
using UnityEngine.UI;

public class FeedbackEffectScript : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Text feedbackText;
    [SerializeField] Outline textOutLine;
    [SerializeField] Shadow textShadow;

    // ----- Set Data -----
    public void SetData(string FeedBackMessages, Color TextMainColor, Color TextOutLineColor)
    {
        feedbackText.text = FeedBackMessages;
        feedbackText.color = TextMainColor;
        textShadow.effectColor = TextOutLineColor;
        textOutLine.effectColor = TextOutLineColor;
    }

    // ----- Get Feed Back Text -----
    public Text GetFeedBackText()
    {
        return feedbackText;
    }

    // ----- Get RectTransform -----
    public RectTransform GetRectTransform()
    {
        return rectTransform;
    }

    // ----- Get Outline -----
    public Outline GetOutline() 
    {
        return textOutLine;
    }

    // ----- Get Shadow -----
    public Shadow GetShadow()
    {
        return textShadow;
    }
}