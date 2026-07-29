using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonControl : MonoBehaviour
{
    private int innerTrigger;
    public int skillInterval;
    public int startDelay;
    // Start is called before the first frame update
    public List<Transform> skillObjectList = new List<Transform>();
    private EnemyHealth EH;
    void Awake() {innerTrigger = 0;EH = GetComponent<EnemyHealth>();}

    // Update is called once per frame
    void Update()
    {
        if(EH.health > 0)
        {
            innerTrigger++;
            if((innerTrigger - startDelay) % skillInterval == 0 && innerTrigger > startDelay)
            {
                doSomeThing();
            }
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
