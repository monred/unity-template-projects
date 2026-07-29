using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public int damageTime = 0;
    public int maxDamageTime = 1;
    public int damageAmount = 0;
    public bool hitEnemy = false;
    public bool hitPlayer = false;
    
    void Awake() {damageTime = 0;}

    private void OnTriggerStay2D(Collider2D other){
        if(damageTime != maxDamageTime){
            if(other.tag == "Enemy" && hitEnemy)
            {
                damageTime++;
                other.GetComponent<EnemyHealth>().takeDamage(damageAmount);
            }
            else if(other.tag == "Player" && hitPlayer)
            {
                damageTime++;
                other.GetComponent<PlayerInformation>().takeDamage(damageAmount);
            }
        }
        
    }
    public void resetDelay(){
        damageTime = 0;
    }
}
