using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private bool dead;
    public Vector3 restPlace;
    private Rigidbody2D rb;
    void Awake() {health = maxHealth; rb = GetComponent<Rigidbody2D>();}

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead){
            rb.position = restPlace;
        }
    }
    public void takeDamage(int amount){
        health -= amount;
        
            if(health <= 0){
                death();
            }
            
        return;
    }

    private void death(){
        dead = true;
        Debug.Log("Enemy dead");
    }
}
