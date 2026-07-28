using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private int maxInvTime = 500;
    private int invTime = 0;
    private SpriteRenderer sprRend;
    
    void Awake() {health = maxHealth; invTime = 0; sprRend = GetComponent<SpriteRenderer>();}

    public void Update(){
        if(invTime > 0){
            invTime--;
            if(invTime % 80 > 40){
                sprRend.color = Color.black;
            }
            else{
                sprRend.color = Color.white;

            }
        }
    }
    
    public void takeDamage(int amount){
        if(invTime == 0){
            invTime = maxInvTime;
            health -= amount;
            if(health <= 0){
                death();
            }
        }
        return;
    }
    private void death(){
        Debug.Log("We dead");
    }
}
