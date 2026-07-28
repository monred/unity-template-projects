using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool _grounded;
    public float jumpForce;
    public float horizSpeed;
    // Start is called before the first frame update
    void Awake() {rb = GetComponent<Rigidbody2D>();}

    // Update is called once per frame
    void Update()
    {
        
    }
}
