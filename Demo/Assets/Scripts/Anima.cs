using UnityEngine;

public class Anima : MonoBehaviour
{
    [SerializeField] private float minimumAttackDelay = 2f;
    [SerializeField] private float maximumAttackDelay = 4f;

    private Animator animator;
    private float nextAttackTime;
    private bool dead;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ScheduleNextAttack();
    }

    private void Update()
    {
        if (dead || Time.time < nextAttackTime)
            return;

        // Randomly choose move 1 (normal attack) or move 2 (special attack).
        string attackTrigger = Random.value < 0.5f
            ? "AttackTrigger"
            : "SpecialATrigger";

        animator.SetTrigger(attackTrigger);
        ScheduleNextAttack();
    }

    public void PlayHitAnimation()
    {
        if (!dead)
            animator.SetTrigger("StunedTrigger");
    }

    public void PlayDeathAnimation()
    {
        if (dead)
            return;

        dead = true;
        animator.SetTrigger("DeathTrigger");
    }

    private void ScheduleNextAttack()
    {
        nextAttackTime = Time.time + Random.Range(minimumAttackDelay, maximumAttackDelay);
    }
}
