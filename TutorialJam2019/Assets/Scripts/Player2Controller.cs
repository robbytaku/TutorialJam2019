using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public int controllerNumber;

    public float moveSpeed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D RB;
    private bool facingRight = true;
    private bool isGrounded;
    public Collider2D P2PunchHitBox;
    public Collider2D P2KickHitBox;
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = .8f;
    private bool blocking = false;
    private float blockTimer = 0;
    public float blockCd = 0.5f;
    private bool kicking = false;
    private float kickTimer = 0;
    private float kickCd = .8f;
    private Animator anim;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        P2PunchHitBox.enabled = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("HorizontalAlt");
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
        if (Input.GetButtonDown("A Button 2"))
        {
            if (isGrounded)
            {
                RB.velocity = Vector2.up * jumpForce;
            }
        }

        if (Input.GetButtonDown("Y Button 2") && !blocking)
        {
            blocking = true;
            blockTimer = blockCd;
            anim.SetTrigger("Block");
            gameObject.tag = "Player2Block";
        }

        if (blocking)
        {
            if (blockTimer > 0)
            {
                blockTimer -= Time.deltaTime;
            }
            else
            {
                blocking = false;
                gameObject.tag = "player2";
            }
        }

        if (Input.GetButtonDown("B Button 2") && !kicking)
        {
            kicking = true;
            kickTimer = kickCd;
            anim.SetTrigger("Kick");
            P2KickHitBox.enabled = true;
        }

        if (kicking)
        {
            if (kickTimer > 0)
            {
                kickTimer -= Time.deltaTime;
            }
            else
            {
                kicking = false;
                P2KickHitBox.enabled = false;
            }
        }

        if (Input.GetButtonDown("X Button 2") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
            anim.SetTrigger("Punch");

            P2PunchHitBox.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                P2PunchHitBox.enabled = false;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(RB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
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

    public void KickP2()
    {
        anim.SetTrigger("Idle");
        gameObject.tag = "player2";
    }
}