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
    private bool tryAttack;
    private bool didAttack;
    private bool tryLeft;
    private bool tryRight;
    private bool didJump;
    private bool tryJump;
    private SpriteRenderer sprRend;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource attackSound;

    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>(); sprRend = GetComponent<SpriteRenderer>(); mA = GetComponent<Animator>();death = false;}

    void Update()
    {
    }
    void FixedUpdate()
    {
        if(Input.GetKey(leftKey)) {tryLeft = true;}
        if(Input.GetKey(rightKey)) {tryRight = true;}
        if(Input.GetKey(attackKey)) {
            if(!didJump){
                tryAttack = true;
            }
            didAttack = true;
        } else{didAttack = false;}
        if(Input.GetKey(jumpKey)) {
            if(!didJump){
                tryJump = true;
            }
            didJump = true;
        } else{didJump = false;}
        start++;
        if(start > 120  && start <= 180){
            rb.velocity = new Vector2(0, 0);
            mA.SetInteger("AnimState", 0);
        }
        if(beBoun){beBoun = !onGrounded;}
        int direcion = 0;
        if(interAttack <= 0 && !death && start > 180 && !beBoun){
            if(onGrounded && tryAttack){
                interAttack = 20;
                if(attackSound != null){
                attackSound.Play();}
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
                attack();
               mA.SetInteger("AnimState",0);
            }
            else{
                damageAre.position = damageAre.GetComponent<ProjectileScri>().restPlace;
                if(tryLeft) {direcion--; sprRend.flipX = true;}
                if(tryRight) {direcion++;  sprRend.flipX = false;}
                if(tryJump && onGrounded) {
                    mA.SetTrigger("Jump");
                    onGrounded = false;
                    rb.velocity = new Vector2(direcion * horizSpeed, jumpForce);
                    if(jumpSound != null){
                        jumpSound.Play();}
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
        if(start <= 120){
                mA.SetBool("Grounded", true);
            mA.SetInteger("AnimState", 1);
            rb.velocity = new Vector2(4.0f, 0);
        }
            tryAttack = false;
            tryJump = false;
            tryLeft = false;
            tryRight = false;
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
                rb.AddForce(transform.right * -20);
            }
            else{
                rb.AddForce(transform.right * 20);
            }
            beBoun = true;
        }
    }
}