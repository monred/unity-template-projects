using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inWork;
    private int innerTimer;
    public Transform player;
    void Awake() {inWork = 0 == 1;}

    // Update is called once per frame
    void Update()
    {
        if (inWork)
        {
            innerTimer++;
            transform.position = new Vector3(30.0f, -8.0f, 0.0f);
            if(innerTimer > 200){
                GetComponent<FireShooter>().trigger();
                inWork = false;
            }
        }
    }
    public void GoWork()
    {
        
        if (!inWork)
        {
            innerTimer = 0;
            inWork = true;
        }
        return;
    }
}
