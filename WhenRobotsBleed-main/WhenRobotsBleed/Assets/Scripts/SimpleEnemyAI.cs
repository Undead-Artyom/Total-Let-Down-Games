using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0f;
    [SerializeField] private float patrolDistance = 5f;
    [SerializeField] private float detectDistance = 3f;
    [SerializeField] private float disengageDistance = 3f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Transform target;
    private Vector2 direction;
    private bool isFacingRight = true;
    private bool isPatrolling = true;
    private bool isAttacking = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

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

            // Stop moving while attacking
            if (distanceToTarget <= 1.5f && !isAttacking)
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
            }

            if (distanceToTarget >= disengageDistance)
            {
                isPatrolling = true;
            }
        }
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

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public bool IsPatrolling()
    {
        return isPatrolling;
    }
}
