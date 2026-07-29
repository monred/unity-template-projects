using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonControl : MonoBehaviour
{
    private int innerTrigger;
    public int skillInterval;
    // Start is called before the first frame update
    public List<Transform> skillObjectList = new List<Transform>();
    void Awake() {innerTrigger = 0;}

    // Update is called once per frame
    void Update()
    {
        innerTrigger++;
        if(innerTrigger % skillInterval == 0)
        {
            doSomeThing();
        }
    }
    private void doSomeThing()
    {
        Debug.Log("doing");
        int attackWay = Random.Range(0,1);
        if(attackWay == 0) {
        skillObjectList[attackWay].GetComponent<SpikeTrigger>().GoWork();}
        else if(attackWay == 1){return;}
    }
}
