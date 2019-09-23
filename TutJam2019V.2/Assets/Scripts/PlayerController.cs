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
    private bool isGrounded;
    public Collider2D P1PunchHitBox;
    public Collider2D P1KickHitBox;
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = .4f;
    private bool blocking = false;
    private float blockTimer = 0;
    public float blockCd = 0.5f;
    private bool kicking = false;
    private float kickTimer = 0;
    private float kickCd = .4f;
    private Animator anim;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        P1PunchHitBox.enabled = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        moveInput += Input.GetAxis("Horizontal 3");
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
        if (Input.GetButtonDown("A Button") || Input.GetButtonDown("A Button 3"))
        {
            if (isGrounded)
            {
                RB.velocity = Vector2.up * jumpForce;
            }
        }

        if (Input.GetButtonDown("Y Button") && (blocking != true) && (kicking != true) && (attacking != true) || Input.GetButtonDown("Y Button 3") && (blocking != true) && (kicking != true) && (attacking != true))
        {
            blocking = true;
            blockTimer = blockCd;
            anim.SetTrigger("Block");
            gameObject.tag = "Player1Block";
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
                gameObject.tag = "player1";
            }
        }

        if (Input.GetButtonDown("B Button") && (blocking != true) && (kicking != true) && (attacking != true) || Input.GetButtonDown("B Button 3") && (blocking != true) && (kicking != true) && (attacking != true))
        {
            kicking = true;
            kickTimer = kickCd;
            anim.SetTrigger("Kick");
            P1KickHitBox.enabled = true;
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
                P1KickHitBox.enabled = false;
            }
        }

        if (Input.GetButtonDown("X Button") && (blocking != true) && (kicking != true) && (attacking != true) || Input.GetButtonDown("X Button 3") && (blocking != true) && (kicking != true) && (attacking != true))
        {
            attacking = true;
            attackTimer = attackCd;
            anim.SetTrigger("Punch");

            P1PunchHitBox.enabled = true;
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
                P1PunchHitBox.enabled = false;
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

    public void KickP1()
    {
        anim.SetTrigger("Idle");
        gameObject.tag = "player1";
    }
}