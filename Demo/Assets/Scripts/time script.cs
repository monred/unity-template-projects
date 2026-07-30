using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timescript : MonoBehaviour


    
{
    public float TimerMaxTimer;
    public float TimerCurrentTimer;
    private string sceneToLoad;
    public TextMeshProUGUI Countdown;
    // Start is called before the first frame update
    void Start()
      
    {
        TimerCurrentTimer = TimerMaxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCurrentTimer -= Time.deltaTime;
        Countdown.text = TimerCurrentTimer.ToString();
        if (TimerCurrentTimer <= 0)

        {
            SceneManager.LoadScene("Start scene");
            
        }



    }
}
