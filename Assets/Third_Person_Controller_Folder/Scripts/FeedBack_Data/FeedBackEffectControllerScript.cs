using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FeedBackEffectControllerScript : MonoBehaviour
{
    [Header("----- Feed Back -----")]
    [SerializeField] RectTransform EffectSpawnParent;
    [SerializeField] FeedbackEffectScript FeedBackEffect;
    List<FeedbackEffectScript> FeedBackEffectStore = new List<FeedbackEffectScript>();
    [Header("----- Feed Back Data -----")]
    [SerializeField] SimpleColorDataScriptable TextMainColors;
    [SerializeField] SimpleColorDataScriptable TextOutlineColors;
    [SerializeField] float stayDuration = 0.5f;
    [SerializeField] float fadeDuration = 1f;

    #region Feed Back Effect Object
    void FeedBackEffectSpawn()
    {
        FeedbackEffectScript feedBack = Instantiate(FeedBackEffect, EffectSpawnParent);
        FeedBackEffectStore.Add(feedBack);
        feedBack.gameObject.SetActive(false);
    }

    FeedbackEffectScript GetFeedBackEffect()
    {
        FeedbackEffectScript feedBack = FeedBackEffectStore.FirstOrDefault(item => !item.gameObject.activeSelf);
        if (feedBack == null)
        {
            FeedBackEffectSpawn();
            feedBack = FeedBackEffectStore.FirstOrDefault(item => !item.gameObject.activeSelf);
        }

        feedBack.gameObject.SetActive(true);
        return feedBack;
    }
    #endregion

    // ----- Show Feedback With Color Index -----
    void ShowFeedbackWithColorIndexFunction(Vector3 targetPosition, int colorindex, string message)
    {
        ShowFeedbackFunction(targetPosition, colorindex, message);
    }

    // ----- Show Feedback -----
    void ShowFeedbackFunction(Vector3 targetPosition, int colorindex, string message)
    {
        // Convert world position to UI canvas position
        Vector2 uiPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(EffectSpawnParent, DelegatesData.GetCamera().WorldToScreenPoint(targetPosition),
            DelegatesData.GetCamera(), out uiPosition);


        FeedbackEffectScript feedbackObject = GetFeedBackEffect();
        feedbackObject.transform.localPosition = uiPosition;

        // Data Set
        feedbackObject.SetData(message, TextMainColors.GetColor(colorindex), TextOutlineColors.GetColor(colorindex));
        feedbackObject.transform.localScale = Vector3.zero;

        // Effect Perform
        // Step 1: Scale in and stay
        StartCoroutine(AnimationEffect.ScaleOutBack(feedbackObject.transform, Vector3.zero, Vector3.one, 0, stayDuration, () =>
        {
            // Store start and end for float up and fade out
            Vector3 startPos = feedbackObject.GetRectTransform().anchoredPosition;
            Vector3 endPos = startPos + new Vector3(0, 50f, 0);
            Color startColor = feedbackObject.GetFeedBackText().color;
            Color endColor = startColor;
            endColor.a = 0f;
            // Step 2: Fade and float
            StartCoroutine(AnimationEffect.RectTransformSmoothMove(feedbackObject.GetRectTransform(), startPos, endPos, fadeDuration));
            StartCoroutine(AnimationEffect.FadeText(feedbackObject.GetFeedBackText(), 1f, 0f, 0f, fadeDuration, () =>
            {
                feedbackObject.gameObject.SetActive(false);
            }));
            StartCoroutine(AnimationEffect.FadeTextOutline(feedbackObject.GetOutline(), 1f, 0f, 0f, fadeDuration));
            StartCoroutine(AnimationEffect.FadeTextShadow(feedbackObject.GetShadow(), 1f, 0f, 0f, fadeDuration));
        }));

        // Sound Play
        SoundManager.Instance.PlaySound(SoundManager.Instance.FeedBackShow);
    }

    private void OnEnable()
    {
        // Show Feedback With Color Index
        DelegatesData.ShowFeedbackWithColorIndex += ShowFeedbackWithColorIndexFunction;
    }

    private void OnDisable()
    {
        // Show Feedback With Color Index
        DelegatesData.ShowFeedbackWithColorIndex -= ShowFeedbackWithColorIndexFunction;
    }
}