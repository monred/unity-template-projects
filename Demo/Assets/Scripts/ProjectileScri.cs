using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScri : MonoBehaviour
{
    private Rigidbody2D rb;
    public DamageArea daAr;
    public Vector3 speed;
    public Vector3 restPlace;
    void Awake() {rb = GetComponent<Rigidbody2D>(); daAr = GetComponent<DamageArea>(); }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(daAr.damageTime != daAr.maxDamageTime){
            rb.velocity = new Vector2(-Mathf.Abs(speed.x), speed.y);
        }
        else{
            rb.position = restPlace;
            rb.velocity = Vector3.zero;
        }
    }
}
