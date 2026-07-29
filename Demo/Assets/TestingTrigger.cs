using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTrigger : MonoBehaviour
{
    private int start = 0;
    // Start is called before the first frame update
    void Start()
    {
        start = 0;
    }

    // Update is called once per frame
    void Update()
    {
        start++;
        if(start % 500 == 0){
            GetComponent<FireShooter>().trigger();
        }
    }
}
