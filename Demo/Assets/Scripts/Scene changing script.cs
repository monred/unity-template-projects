using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechangingscript : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1.0f;
    
    
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeRoutine(sceneName));
    }

    private IEnumerator FadeRoutine(string sceneName)
    {
        if (fadeCanvasGroup != null)
        {
            yield return StartCoroutine(Fade(0f, 1f));
            SceneManager.LoadScene(sceneName);
            yield return StartCoroutine(Fade(1f, 0f));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeCanvasGroup.alpha = alpha;
            yield return null;
        }
        // Ensure final alpha is set
        if (fadeCanvasGroup != null) fadeCanvasGroup.alpha = endAlpha;
         fadeCanvasGroup.interactable = endAlpha == 0f;
    }
}