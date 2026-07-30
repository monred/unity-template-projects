using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("The exact name of your Game Over scene")]
    [SerializeField] private string gameOverSceneName = "You lost lol you suck";

    public void TriggerDeath()
    {
        if (string.IsNullOrEmpty(gameOverSceneName))
        {
            Debug.LogWarning("DeathScript: No game over scene name assigned.");
            return;
        }

        SceneManager.LoadScene(gameOverSceneName);
    }
}
