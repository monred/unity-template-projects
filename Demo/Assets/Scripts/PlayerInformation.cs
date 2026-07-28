using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private int maxInvTime = 100;
    private int invTime = 0;
    
    void Awake() {health = maxHealth; invTime = 0;}
    
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
