using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
        
    void Awake() {health = maxHealth;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int amount){
        health -= amount;
        
            if(health <= 0){
                death();
            }
            
        return;
    }

    private void death(){
        Debug.Log("Enemy dead");
    }
}
