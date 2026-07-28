using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool onGrounded;
    public float jumpForce;
    public float horizSpeed;
    public KeyCode jumpKey;
    public KeyCode leftKey;
    public KeyCode squatKey;
    public KeyCode rightKey;
    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>();}

    void FixedUpdate()
    {
        int direcion = 0;
        int jum = 0;
        if(Input.GetKeyDown(leftKey)) {direcion--;}
        if(Input.GetKeyDown(rightKey)) {direcion++;}
        if(Input.GetKeyDown(jumpKey) && onGrounded) {
            jum = 1;
        }
        rb.velocity = new Vector2(direcion * horizSpeed, jum * jumpForce);
        
    }
}
