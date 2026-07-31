using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("The exact name of your Game Over scene")]
    [SerializeField] private string gameOverSceneName = "LostSce";
    [SerializeField] private float delayBeforeGameOver = 3f;

    public void TriggerDeath()
    {
        if (string.IsNullOrEmpty(gameOverSceneName))
        {
            Debug.LogWarning("DeathScript: No game over scene name assigned.");
            return;
        }

        StartCoroutine(LoadGameOverAfterDelay());
    }

    private IEnumerator LoadGameOverAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeGameOver);
        SceneManager.LoadScene(gameOverSceneName);
    }
}
