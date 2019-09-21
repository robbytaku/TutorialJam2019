using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D RB;

    private bool facingRight = true;

    private bool Grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2(moveInput * moveSpeed, RB.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Grounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("A Button") && extraJumps > 0)
        {
            RB.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetButtonDown("A Button") && extraJumps == 0 && Grounded == true)
        {
            RB.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}