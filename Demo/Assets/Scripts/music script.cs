using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining=15f;
    private bool timerIsRunning = true;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timerIsRunning = false;
            }
        }
    }

    // Update is called once per frame
    void TriggerAction()
    {
        Debug.Log("Countdown hit 0! Starting script...");   
    }
}
