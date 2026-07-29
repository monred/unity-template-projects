using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;
    private int maxInvTime = 600;
    private int invTime = 0;
    private bool deathBe;
    private PlayerControl pcC;
    private Animator mA;
    private SpriteRenderer sprRend;
    [SerializeField] AudioSource injuredSound;
    
    void Awake() {deathBe = false; health = maxHealth; invTime = 0; sprRend = GetComponent<SpriteRenderer>(); mA = GetComponent<Animator>(); pcC = GetComponent<PlayerControl>();}

    public void Update(){
        if(invTime > 0){
            invTime--;
            if(invTime % 100 > 50){
                sprRend.color = Color.black;
            }
            else{
                sprRend.color = Color.white;

            }
        }
    }
    
    public void takeDamage(int amount){
        if(invTime == 0 && !deathBe){
            mA.SetTrigger("Hurt");
            invTime = maxInvTime;
            health -= amount;
            if(injuredSound != null)
            {
            injuredSound.Play();
            }
            if(health <= 0){
            deathBe = true;
                death();
            }
        }
        return;
    }
    private void death(){
        mA.SetTrigger("Death");
        Debug.Log("We dead");
        pcC.death = true;
    }
}
