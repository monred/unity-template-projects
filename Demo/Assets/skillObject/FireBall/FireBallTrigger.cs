using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inWork;
    public Transform player;
    void Awake() {inWork = 0 == 1;}
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWork)
        {
            transform.position = new Vector3(30.0f, -3.5f + (Random.Range(0,2) * -5.0f), 0.0f);
            GetComponent<FireShooter>().trigger();
            inWork = false;
        }
    }

    public void GoWork()
    {
        if (!inWork)
        {
            inWork = true;
        }
        return;
    }
}
