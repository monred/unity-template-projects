using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool onGrounded;
    public float jumpForce;
    public float horizSpeed;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode squatKey = KeyCode.C;
    public KeyCode attackKey = KeyCode.Mouse0;
    private Animator mA;
    private SpriteRenderer sprRend;
    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>(); sprRend = GetComponent<SpriteRenderer>(); mA = GetComponent<Animator>();}

    void Update()
    {
        int direcion = 0;
        if(onGrounded && Input.GetKeyDown(attackKey)){
            attack();
        }
        else{
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
    public void attack(){
        int attackWay = Random.Range(1,4);
        mA.SetTrigger("Attack" + attackWay);
        return;
    }
}
