using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Anima : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetTrigger("AttackTrigger");
    }

    public void SpecialAttack()
    {
        animator.SetTrigger("SpecialATrigger");
    }

    public void Move()
    {
        animator.SetTrigger("MoveTrigger");
    }

    public void TakeHit()
    {
        animator.SetTrigger("StunedTrigger");
    }

    public void Die()
    {
        animator.SetTrigger("DeathTrigger");
    }

    // Temporary keyboard testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Attack();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpecialAttack();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            TakeHit();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            Die();
    }
}