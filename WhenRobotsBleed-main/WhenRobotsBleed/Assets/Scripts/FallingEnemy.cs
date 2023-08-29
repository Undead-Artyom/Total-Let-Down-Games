using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour
{
    public Transform player;
    public float fallSpeed = 10f;
    public float resetTime = 5f;
    public float FallDetect = 10f;
    public float fallDelay = 3f;

    private Vector3 startingPosition;
    private bool isFalling = false;
    private float resetTimer = 0f;
    private float fallTimer = 0f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < FallDetect && !isFalling && fallTimer >= fallDelay)
        {
            isFalling = true;
        }

        if (isFalling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }

        if (transform.position.y < -40f)
        {
            ResetEnemy();
        }

        if (isFalling && resetTimer < resetTime)
        {
            resetTimer += Time.deltaTime;
        }
        else if (isFalling && resetTimer >= resetTime)
        {
            ResetEnemy();
        }

        if (fallTimer < fallDelay)
        {
            fallTimer += Time.deltaTime;
        }
    }

    void ResetEnemy()
    {
        transform.position = startingPosition;
        isFalling = false;
        resetTimer = 0f;
        fallTimer = 0f;
    }
}
