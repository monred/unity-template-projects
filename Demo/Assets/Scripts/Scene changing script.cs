using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenechangingscript : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1.0f;
    public Image sr;
    
    public void FadeToScene(string sceneName)
    {
        sr.gameObject.SetActive(true);
        StartCoroutine(FadeTransition(sceneName));
    }

    private IEnumerator FadeTransition(string sceneName)
    {
        Color tempColor = sr.color;

        while (sr.color.a < 1f)
        {
            tempColor.a += 0.01f;
            Debug.Log("Alpha: " + tempColor.a);
            sr.color = tempColor;
            yield return new WaitForSeconds(0.01f);
        }
        
        SceneManager.LoadScene("TestScene");  
    }
}
    