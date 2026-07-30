using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
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
            innerRunner++;
            if(innerRunner % 45 == 0)
            {
                transform.position = new Vector3(player.position.x, -10.0f, player.position.z);
                GetComponent<FireShooter>().trigger();
            }
            if(innerRunner == 225)
            {
                inWork = false;
            }
        }
    }

    public void GoWork()
    {
        if (!inWork)
        {
            inWork = true;
            innerRunner = 0;
        }
        return;
    }
}
