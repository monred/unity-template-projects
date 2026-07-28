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
    public KeyCode squatKey = KeyCode.C;
    public KeyCode rightKey = KeyCode.D;
    private SpriteRenderer sprRend;
    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>(); sprRend = GetComponent<SpriteRenderer>();}

    void Update()
    {
        int direcion = 0;
        if(Input.GetKey(leftKey)) {direcion--;}
        if(Input.GetKey(rightKey)) {direcion++;}
        if(Input.GetKeyDown(jumpKey) && onGrounded) {
            rb.velocity = new Vector2(direcion * horizSpeed, jumpForce);
        }
        else{
            rb.velocity = new Vector2(direcion * horizSpeed, rb.velocity.y);
        }
        
    }
}
