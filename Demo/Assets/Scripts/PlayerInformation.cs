using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private int maxInvTime = 1000;
    private int invTime = 0;
    private Animator mA;
    private SpriteRenderer sprRend;
    
    void Awake() {health = maxHealth; invTime = 0; sprRend = GetComponent<SpriteRenderer>(); mA = GetComponent<Animator>();}

    public void Update(){
        if(invTime > 0){
            invTime--;
            if(invTime % 400 > 250){
                sprRend.color = Color.black;
            }
            else{
                sprRend.color = Color.white;

            }
        }
    }
    
    public void takeDamage(int amount){
        if(invTime == 0){
            mA.SetTrigger("Hurt");
            invTime = maxInvTime;
            health -= amount;
            if(health <= 0){
                death();
            }
        }
        return;
    }
    private void death(){
        mA.SetTrigger("noBlood");
        Debug.Log("We dead");
    }
}
