using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DefaultExecutionOrder(300)]
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

    private float _originalGravity;

    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter; 

    public float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public bool hasDash = true;
    private bool canDash = true;
    private bool isDashing;
    [SerializeField]
    private float dashingPower = 5f;
    [SerializeField]
    private float _dashingTime = 0.5f;
    public float dashingTime => _dashingTime;


    [SerializeField]
    private float _dashingCooldown = 2f;
    public float dashingCooldown => _dashingCooldown;



    [SerializeField]
    private float dashCD = 1f;

    public bool hasGrapple = true; //change to public to alow for ablility unlock
    private bool canGrapple = true;
    private bool isGrappling;
    [SerializeField]
    private float grapplePower = 5f;
    [SerializeField]
    private float grappleTime = 0.5f;
    [SerializeField]
    private float grappleCD = 2f;
    [SerializeField]
    private float grappleCurrCD = 1f;
    private ClosestPointTracker grappleTracker;

    public float KBForce = 5f;
    public float KBCounter = 0f;
    public float KBTotalTime = 0.2f;
    public bool KnockFromRight = true;

    private Animator animator;

    //keycard check 
    [SerializeField] public bool hasKeyCard;
    [SerializeField] private int keycards;
    static int totalKeyCards;
    [SerializeField] public bool AllKeyCards = false;

    Vector2 move;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        _originalGravity = rb.gravityScale;
        //grappleTracker = GetComponent<Test_CircularRadiusV7>();
        //dashCD = _dashingCooldown;
    }

    void Start()
    {
        grappleTracker = this.transform.Find("GrappleMachine").GetComponent<ClosestPointTracker>();
    }

    void Update()
    {
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).speed);
        if (dashCD >= 0)
        {   
            dashCD -= Time.deltaTime;
        }
        if (grappleCurrCD >= 0)
        {   
            grappleCurrCD -= Time.deltaTime;
        }
        if (isDashing)
        {
            return;
        }
        if (isGrappling)
        {
            return;
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = checkGrounded();

        // Handle movement input
        // Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));



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
            /*
            if (Input.GetKeyDown(KeyCode.L) && canDash)
            {
                Debug.Log("here");
                if (dashCD <= 0f)
                {
                    StartCoroutine(Dash());
                    dashCD = _dashingCooldown;
                }

            }
            */
            if (Input.GetKeyDown(KeyCode.L))
            {
                if(canDash)
                {
                    if (dashCD <= 0f)
                    {
                        StartCoroutine(Dash());
                        dashCD = _dashingCooldown;
                    }
                }
            }
        }
        if (hasGrapple)
        {
            if (Input.GetKeyDown(KeyCode.H) && canGrapple)
            {
                if (grappleCurrCD <= 0f && grappleTracker.closestPointInLineOfSight)
                {
                    StartCoroutine(Grapple());
                    grappleCurrCD = grappleCD;
                }

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

        animator.SetBool("IsJumping", !isGrounded);
        //rb.velocity = movement;

    }

    void FixedUpdate()
    {

        if (isDashing){
            return;
        }
        if (isGrappling)
        {
            return;
        }
        if(KBCounter <= 0f){
            if(Input.GetKey(KeyCode.LeftShift)){
                animator.SetBool("IsRunning", true);
                rb.velocity = new Vector2(horizontal * speed * 1.5f, rb.velocity.y);
            }
            else{
                animator.SetBool("IsRunning", false);
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            
        }
        else{
            if(KnockFromRight == false){
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            if(KnockFromRight == true){
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }

    void OnDisable(){
        CoroutinePrematureEnd();
        StopAllMyCouroutines();
    }

    private bool checkGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .05f, LayerMask.GetMask("Platform", "Floating Platform", "Ground"));
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
    private IEnumerator Grapple()
    {
        canGrapple = false;
        isGrappling = true;
        canDash = false;
        isDashing = false;
        //float originalGravity = rb.gravityScale; 
        _originalGravity = rb.gravityScale; 
        rb.gravityScale = 0f;
        //Debug.Log("here");
        rb.velocity = (grappleTracker.closestPointLocation-this.transform.position) * (grappleTracker.closestDistance*0.4f);
        yield return new WaitForSeconds(grappleTime);
        rb.gravityScale = _originalGravity;
        //isDashing = false;
        isGrappling = false;
        canGrapple = true;
        canDash = true;
    }

    private IEnumerator Dash()
    {
        canGrapple = false;
        isGrappling = false;
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale; 
        rb.gravityScale = 0f;
        if(isFacingRight == true){
            rb.velocity = new Vector2(speed + dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(_dashingTime);
            tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(_dashingTime);
            canDash = true;
            canGrapple = true;
            isGrappling = false;
        }
        else{
            rb.velocity = new Vector2(-speed + -dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(_dashingTime);
            tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(_dashingTime);
            canDash = true;
            canGrapple = true;
            isGrappling = false;
        }
        //rb.velocity = new Vector2(horizontalInput * dashingPower, 0f);
        // tr.emitting = true;
        // yield return new WaitForSeconds(_dashingTime);
        // tr.emitting = false;
        // rb.gravityScale = originalGravity;
        // isDashing = false;
        // yield return new WaitForSeconds(_dashingTime);
        // canDash = true;
    }

    public void HasAKeyCard()
    {
        hasKeyCard = true;
        keycards += 1;
        totalKeyCards += 1;
        print("totalKeyCards = " + totalKeyCards);
        print(hasKeyCard);
    }

    public void KeyCardUsed()
    {
        if (hasKeyCard)
        {
            hasKeyCard = false;
        }      
    }
    public void FinalKeyCards()
    {
        if(totalKeyCards >= 4)
        {
            AllKeyCards = true; 
        }
    }

    public void StopAllMyCouroutines(){
        StopAllCoroutines();
    }

    public void CoroutinePrematureEnd(){
        tr.emitting = false;
        rb.gravityScale = _originalGravity;
        isDashing = false;
        canDash = true;
        isGrappling = false;
        canGrapple = true;
    }
}

