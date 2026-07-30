using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("The exact name of your Game Over scene")]
    public string gameOverSceneName = "You lost lol you suck";
    public void TriggerDeath()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
