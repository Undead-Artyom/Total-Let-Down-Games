using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAI : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0f;
    [SerializeField] private float patrolDistance = 5f;
    [SerializeField] private float detectDistance = 10f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask floatingPlatformsLayer;


    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Transform target;
    private Vector2 direction;
    private bool isFacingRight = true;
    private bool isPatrolling = true;
    private bool isAttacking = false;

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    private bool IsOnFloatingPlatform()
    {
        // Check if enemy is standing on a floating platform
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f, floatingPlatformsLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsPlayerOnFloatingPlatform()
    {
        // Check if the player is on a floating platform
        RaycastHit2D hit = Physics2D.Raycast(target.position, Vector2.down, Mathf.Infinity, floatingPlatformsLayer);
        return hit.collider != null;
    }

    public bool IsPatrolling()
    {
        return isPatrolling;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        // Chasing
        if (!isPatrolling)
        {
            direction = target.position - transform.position;
            direction.y = 0;

            if (direction.x > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && isFacingRight)
            {
                Flip();
            }

            RaycastHit2D hitWall = Physics2D.Raycast(transform.position, direction.normalized, 1f, groundLayer);

            // Jump when colliding with wall
            //if (hitWall.collider != null)
            if (hitWall.collider != null || (IsPlayerOnFloatingPlatform()))
            {
                if (IsGrounded())
                {
                    // Debug.Log("Hit wall while facing " + (isFacingRight ? "right" : "left"));
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }

            // Stop moving while attacking
            /*if (distanceToTarget <= 1.5f && !isAttacking)
            {
                rb.velocity = Vector2.zero;
                isAttacking = true;
            }
            else if (isAttacking)
            {
                rb.velocity = Vector2.zero;
            }
            if (distanceToTarget > 1.5f)
            {
                isAttacking = false;
            }*/
        }
        // Patrol
        if (isPatrolling)
        {
            direction = isFacingRight ? Vector2.right : Vector2.left;
            float distanceToStart = Mathf.Abs(transform.position.x - rb.position.x);

            if (distanceToStart >= patrolDistance || Physics2D.Raycast(transform.position, direction, 1f, groundLayer))
            {
                Flip();
            }

            // try to detect player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, detectDistance, LayerMask.GetMask("Player"));

            if (hit.collider != null)
            {
                // Debug.DrawRay(transform.position, direction.normalized * detectDistance, Color.green);
                if (hit.collider.CompareTag("Player"))
                {
                    //Debug.Log("Saw Player");
                    isPatrolling = false;
                }
      
            }
            else
            {
                //Debug.DrawRay(transform.position, direction.normalized * detectDistance, Color.red);
            }
        }

        if (!isAttacking)
        {
            rb.velocity = new Vector2(direction.x * _movementSpeed, rb.velocity.y);
        }
    }
}

