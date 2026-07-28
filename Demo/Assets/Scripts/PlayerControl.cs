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
    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>();}

    void Update()
    {
        int direcion = 0;
        int jum = 0;
        if(Input.GetKey(leftKey)) {direcion--;}
        if(Input.GetKey(rightKey)) {direcion++;}
        if(Input.GetKey(jumpKey) && onGrounded) {
            jum = 1;
        }
        rb.velocity = new Vector2(direcion * horizSpeed, jum * jumpForce);
        
    }
}
