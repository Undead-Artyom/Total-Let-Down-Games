using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpMid = 0.6f;
    [SerializeField] private TrailRenderer tr;

    private float horizontal;
    private bool isFacingRight = true;

    public Rigidbody2D rb;

    private BoxCollider2D coll;
    public bool isGrounded = false;
    public bool hasJump = true;
    private float horizontalInput;

    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter; 

    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public bool hasDash = false;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = checkGrounded();

        // Handle movement input
        // Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        horizontal = Input.GetAxisRaw("Horizontal");


        Flip();

        //Flip player when moving left-right
        /* if (horizontalInput > 0.01f)
            //transform.localScale = Vector3.one;
            rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        else if (horizontalInput < -0.01f)
            //transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        */

        //dash ablility 
        if (hasDash)
        {
            if (Input.GetKeyDown(KeyCode.Z) && canDash)
            {
                StartCoroutine(Dash());
            }
        }



        // Handle jumping input
        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            movement.y = jumpForce;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonUp("Jump") && movement.y > 0f)
        {
            movement.y = jumpForce * jumpMid;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }*/

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (hasJump == true) //this check if player can jump 
        {
            if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
            {
                //movement.y = jumpForce;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                hasJump = false;
                jumpBufferCounter = 0f;
            }
            //this give variable jumps 
            else if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                //movement.y = jumpForce * jumpMid;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpMid);
                hasJump = false;
                coyoteTimeCounter = 0f;
            }
        }

        if (isGrounded) //this help with giving jump back affter player is grounded. also with coyote time 
        {
            hasJump = true;
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //rb.velocity = movement;

    }

    private void FixedUpdate()
    {
         if (isDashing)
        {
            return;
        }

        //movment here 
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool checkGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, LayerMask.GetMask("Platform", "Floating Platform", "Ground"));
    }

    public bool canAttack()
    {
        return true;
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;

            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale; 
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontalInput * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingTime);
        canDash = true;
    }
}

