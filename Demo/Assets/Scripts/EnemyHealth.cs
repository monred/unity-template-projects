using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Vector3 restPlace;
    private Animator mA;
    private bool getMA;
    public int deadDelay = 0;

    
    private bool dead;
    private Rigidbody2D rb;

    private void Awake()
    {
        getMA = GetComponent<Animator>() != null;
        if(getMA){
            deadDelay = 500;
            mA = GetComponent<Animator>();
        }
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        dead = false;
    }

    public void takeDamage(int amount)
    {
        if (dead)
            return;

        health -= amount;

        if (health <= 0)
        {
            death();
        }
    }

    private void death()
    {
        if(getMA){
            mA.SetTrigger("DeathTrigger");
        }
        transform.position = restPlace;
        dead = true;
    }
}
