using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Vector3 restPlace;

    
    private bool dead;
    private Rigidbody2D rb;

    private void Awake()
    {
        
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
        transform.position = restPlace;
        dead = true;
        Debug.Log("Enemy dead");
    }
}
