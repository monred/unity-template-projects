using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonControl : MonoBehaviour
{
    private int innerTrigger;
    public int skillInterval;
    public int startDelay;
    private Animator mA;
    private bool getMA;
    // Start is called before the first frame update
    public List<Transform> skillObjectList = new List<Transform>();
    private EnemyHealth EH;
    void Awake() {
        innerTrigger = 0;
        EH = GetComponent<EnemyHealth>();
        getMA = GetComponent<Animator>() != null;
        if(getMA){
            mA = GetComponent<Animator>();
        }
    
    }

    // Update is called once per frame
    void FixedUpdate()
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
        int attackWay = Random.Range(0,2);
        if(attackWay == 0) {
        skillObjectList[attackWay].GetComponent<SpikeTrigger>().GoWork();
        if(getMA){
            mA.SetTrigger("AttackTrigger");
        }
        }
        else if(attackWay == 1){
        skillObjectList[attackWay].GetComponent<FireBallTrigger>().GoWork();
        if(getMA){
            mA.SetTrigger("SpecialATrigger");
        }
        }
    }
}
