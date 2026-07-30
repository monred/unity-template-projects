using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScri : MonoBehaviour
{
    private Rigidbody2D rb;
    public DamageArea daAr;
    public int deathTrigger;
    private int i = 0;
    public Vector3 speed;
    public Vector3 restPlace;
    void Awake() {rb = GetComponent<Rigidbody2D>(); daAr = GetComponent<DamageArea>(); i = 0;}
    // Start is called before the first frame update
    // Update is called once per frame
    void FixedUpdate()
    {
        if(daAr.damageTime == daAr.maxDamageTime || i == deathTrigger){
            rb.position = restPlace;
            rb.velocity = Vector3.zero;
        }
        else{
            i++;
            rb.velocity = new Vector2(speed.x, speed.y);
        }
    }
    public void resetDelay(){
        i = 0;
    }
}
