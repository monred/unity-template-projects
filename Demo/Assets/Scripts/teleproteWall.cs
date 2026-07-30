using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleproteWall : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPosition;
    public int trigger;
    private int nu;
    void Start()
    {
        nu = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(nu < trigger){
            nu++;
        }
        else{
            transform.position = targetPosition;
        }

    }
}
