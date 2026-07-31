using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inWork;
    public Transform player;
    private int innerRunner;
    void Awake() {inWork = 0 == 1;}
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWork)
        {
            if(innerRunner % 120 == 0)
            {
                transform.position = new Vector3(30.0f, -3.5f + (Random.Range(0,2) * -5.0f), 0.0f);
                GetComponent<FireShooter>().trigger();
            }
            if(innerRunner == 120)
            {
                inWork = false;
            }
            innerRunner++;
        }
    }

    public void GoWork()
    {
        if (!inWork)
        {
            innerRunner = 0;
            inWork = true;
        }
        return;
    }
}
