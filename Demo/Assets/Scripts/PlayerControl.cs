using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool roll;
    public bool onGrounded;
    public float jumpForce;
    public float horizSpeed;
    public int interAttack;
    public int start = 0;
    public bool death = false;
    public Transform damageAre;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode squatKey = KeyCode.C;
    public KeyCode attackKey = KeyCode.Mouse0;
    private Animator mA;
    private bool beBoun;
    private SpriteRenderer sprRend;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource attackSound;

    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>(); sprRend = GetComponent<SpriteRenderer>(); mA = GetComponent<Animator>();death = false;}

    void FixedUpdate()
    {
        start++;
        if(start > 800  && start <= 1200){
            rb.velocity = new Vector2(0, 0);
            mA.SetInteger("AnimState", 0);
        }
        if(beBoun){beBoun = !onGrounded;}
        int direcion = 0;
        if(interAttack <= 0 && !death && start > 1200 && !beBoun){
            if(onGrounded && Input.GetKeyDown(attackKey)){
                interAttack = 80;
                if(attackSound != null){
                attackSound.Play();}
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
                    onGrounded = false;
                if(jumpSound != null){
                jumpSound.Play();}
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
        if(start <= 800){
                mA.SetBool("Grounded", true);
            mA.SetInteger("AnimState", 1);
            rb.velocity = new Vector2(4.0f, 0);
        }
    }
    public void attack(){
        if(damageAre!= null){
            if(sprRend.flipX){
                damageAre.position = new Vector3(transform.position.x + -0.9f, transform.position.y + 0.7f, transform.position.z + 0.0f);
            }
            else{
                damageAre.position = new Vector3(transform.position.x + 0.9f, transform.position.y + 0.7f, transform.position.z + 0.0f);
            }
        }
        int attackWay = Random.Range(1,4);
        resetProjec(damageAre);
        mA.SetTrigger("Attack" + attackWay);
        return;
    }
    public void resetProjec(Transform projec){
        projec.GetComponent<DamageArea>().resetDelay();
        projec.GetComponent<ProjectileScri>().resetDelay();
    }
    public void OnCollisionStay2D(Collision2D other){
        if(!onGrounded && other.gameObject.tag == "Wall" && other.gameObject.transform.position.y > transform.position.y){
            if(other.gameObject.transform.position.x > transform.position.x){
                rb.AddForce(transform.right * -800);
            }
            else{
                rb.AddForce(transform.right * 800);
            }
            beBoun = true;
        }
    }
}