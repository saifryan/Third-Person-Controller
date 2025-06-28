using System.Collections;
using UnityEngine;

public class AnimationEffect
{
    // ----- RectTransform Smooth Move -----
    public static IEnumerator RectTransformSmoothMove(RectTransform obj, Vector3 startPos, Vector3 endPos, float duration, System.Action onComplete = null)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            obj.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.position = endPos;

        onComplete?.Invoke();
    }

    // ----- Scale OutBack -----
    public static IEnumerator ScaleOutBack(Transform target, Vector3 startScale, Vector3 endScale, float startdelay, float duration, System.Action onComplete = null)
    {
        target.localScale = startScale;
        yield return new WaitForSeconds(startdelay);
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            t = EaseOutBack(t);
            target.localScale = Vector3.LerpUnclamped(startScale, endScale, t);
            time += Time.deltaTime;
            yield return null;
        }
        target.localScale = endScale;
        // Call the callback
        onComplete?.Invoke();
    }

    // ----- Scale InBack -----
    public static IEnumerator ScaleInBack(Transform target, Vector3 startScale, Vector3 endScale, float startdelay, float duration, System.Action onComplete = null)
    {
        target.localScale = startScale;
        yield return new WaitForSeconds(startdelay);
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            t = EaseInBack(t);
            target.localScale = Vector3.LerpUnclamped(startScale, endScale, t);
            time += Time.deltaTime;
            yield return null;
        }

        target.localScale = endScale;
        // Call the callback
        onComplete?.Invoke();
    }

    // ----- Fade Image -----
    public static IEnumerator FadeImage(UnityEngine.UI.Image img, float startAlpha, float endAlpha, float startdelay, float fadeDuration, System.Action effectcomplete = null)
    {
        // Set initial alpha when coroutine starts
        Color color = img.color;
        img.color = new Color(color.r, color.g, color.b, startAlpha);

        yield return new WaitForSeconds(startdelay);

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            img.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure final alpha
        img.color = new Color(color.r, color.g, color.b, endAlpha);
        // Effect Complete
        effectcomplete?.Invoke();
    }

    // ----- Fade Text -----
    public static IEnumerator FadeText(UnityEngine.UI.Text txt, float startAlpha, float endAlpha, float startdelay, float fadeDuration, System.Action effectcomplete = null)
    {
        // Set initial alpha when coroutine starts
        Color color = txt.color;
        txt.color = new Color(color.r, color.g, color.b, startAlpha);

        yield return new WaitForSeconds(startdelay);

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            txt.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure final alpha
        txt.color = new Color(color.r, color.g, color.b, endAlpha);
        // Effect Complete
        effectcomplete?.Invoke();
    }

    // ----- Fade Outline Text -----
    public static IEnumerator FadeTextOutline(UnityEngine.UI.Outline outline, float startAlpha, float endAlpha, float startdelay, float fadeDuration, System.Action effectcomplete = null)
    {
        // Set initial alpha when coroutine starts
        Color color = outline.effectColor;
        outline.effectColor = new Color(color.r, color.g, color.b, startAlpha);

        yield return new WaitForSeconds(startdelay);

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            outline.effectColor = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure final alpha
        outline.effectColor = new Color(color.r, color.g, color.b, endAlpha);
        // Effect Complete
        effectcomplete?.Invoke();
    }

    // ----- Fade Shadow Text -----
    public static IEnumerator FadeTextShadow(UnityEngine.UI.Shadow shadow, float startAlpha, float endAlpha, float startdelay, float fadeDuration, System.Action effectcomplete = null)
    {
        // Set initial alpha when coroutine starts
        Color color = shadow.effectColor;
        shadow.effectColor = new Color(color.r, color.g, color.b, startAlpha);

        yield return new WaitForSeconds(startdelay);

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            shadow.effectColor = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure final alpha
        shadow.effectColor = new Color(color.r, color.g, color.b, endAlpha);
        // Effect Complete
        effectcomplete?.Invoke();
    }

    // ----- EaseInBack -----
    public static float EaseInBack(float t)
    {
        float s = 1.70158f;
        return t * t * ((s + 1) * t - s);
    }

    // ----- EaseOutBack -----
    public static float EaseOutBack(float t)
    {
        float s = 1.70158f;
        t -= 1;
        return t * t * ((s + 1) * t + s) + 1;
    }
}