using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool onGrounded;
    public float jumpForce;
    public float horizSpeed;
    public int interAttack;
    public bool death = false;
    public Transform damageAre;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode squatKey = KeyCode.C;
    public KeyCode attackKey = KeyCode.Mouse0;
    private Animator mA;
    private SpriteRenderer sprRend;
    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>(); sprRend = GetComponent<SpriteRenderer>(); mA = GetComponent<Animator>();death = false;}

    void Update()
    {
        int direcion = 0;
        if(interAttack <= 0 && !death){
            if(onGrounded && Input.GetKeyDown(attackKey)){
                interAttack = 80;
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
                attack();
               mA.SetInteger("AnimState",0);
            }
            else{
                damageAre.position = damageAre.GetComponent<ProjectileScri>().restPlace;
                if(Input.GetKey(leftKey)) {direcion--; sprRend.flipX = true;}
                if(Input.GetKey(rightKey)) {direcion++;  sprRend.flipX = false;}
                if(Input.GetKeyDown(jumpKey) && onGrounded) {
                    mA.SetTrigger("Jump");
                    rb.velocity = new Vector2(direcion * horizSpeed, jumpForce);
                }
                else{
                    rb.velocity = new Vector2(direcion * horizSpeed, rb.velocity.y);
                }
                mA.SetInteger("AnimState", Mathf.Abs(direcion));
                mA.SetBool("Grounded", onGrounded);
                mA.SetFloat("AirSpeedY", rb.velocity.y);
            }
        }
        if(death){
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
        interAttack--;
    }
    public void attack(){
        if(damageAre!= null){
            if(sprRend.flipX){
                damageAre.position = new Vector3(transform.position.x + -0.9f, transform.position.y + 0.7f, transform.position.z + 0f);
            }
            else{
                damageAre.position = new Vector3(transform.position.x + 0.9f, transform.position.y + 0.7f, transform.position.z + 0.0f);
            }
        }
        int attackWay = Random.Range(1,4);
        mA.SetTrigger("Attack" + attackWay);
        return;
    }
}
