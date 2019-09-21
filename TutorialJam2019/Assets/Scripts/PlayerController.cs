using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int controllerNumber;

    public float moveSpeed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D RB;
    private bool facingRight = true;
    private bool isGrounded;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
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
        if (Input.GetButtonDown("A Button"))
        {
            if (isGrounded)
            {
                RB.velocity = Vector2.up * jumpForce;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            isGrounded = false;
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