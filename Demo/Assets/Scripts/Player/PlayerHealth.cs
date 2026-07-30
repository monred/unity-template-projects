using UnityEngine;
using UnityEngine.SceneManagement;

// INFORMATION ==================================================
// This script handles logic for players to allow taking damage
// and healing.
// ==============================================================
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private DeathScript deathScript;

    void Awake()
    {
        _health = _maxHealth;

        if (deathScript == null)
        {
            deathScript = FindObjectOfType<DeathScript>();
        }
    }

    //Subtract amount from health, checks for health below zero
    public void DealDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0) {PlayerLose();}
    }

    //Heals amount of health, cannot overheal
    public void HealHealth(float amount)
    {
        _health += amount;
        if (_health > _maxHealth) {_health = _maxHealth;}
    }

    //Implement logic for when the player runs out of health here
    private void PlayerLose()
    {
        Debug.Log("Player has lost the game");

        if (deathScript != null)
        {
            deathScript.TriggerDeath();
        }
        else
        {
            SceneManager.LoadScene("You lost lol you suck");
        }
    }
}
