using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Vector3 restPlace;

    private bool dead;
    private Rigidbody2D rb;
    private Anima dragonAnimation;

    private void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        dragonAnimation = GetComponent<Anima>();

        // TestScene does not currently have Anima attached, so add it automatically.
        if (dragonAnimation == null)
            dragonAnimation = gameObject.AddComponent<Anima>();
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
        else
        {
            // Move 3: the dragon's hit/stunned animation.
            dragonAnimation.PlayHitAnimation();
        }
    }

    private void death()
    {
        dead = true;
        dragonAnimation.PlayDeathAnimation();
        Debug.Log("Enemy dead");
        StartCoroutine(MoveAwayAfterDeath());
    }

    private IEnumerator MoveAwayAfterDeath()
    {
        // Give the death animation time to finish before hiding the dragon.
        yield return new WaitForSeconds(1.5f);

        if (rb != null)
            rb.position = restPlace;
        else
            transform.position = restPlace;
    }
}
