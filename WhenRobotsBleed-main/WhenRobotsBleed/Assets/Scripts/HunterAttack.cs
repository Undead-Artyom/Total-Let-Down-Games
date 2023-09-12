using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAttack : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float cooldownTime = 2.0f;

    private PlayerHealth playerHealth;
    private HunterAI trackPatrolling;
    private bool canAttack = true;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        trackPatrolling = gameObject.GetComponent<HunterAI>();
    }

    void Update()
    {
        if (canAttack && !trackPatrolling.IsPatrolling() && Vector2.Distance(transform.position, playerHealth.transform.position) <= 1.5f)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Player took " + damageAmount + " damage");
            canAttack = false;
            Invoke("ResetAttack", cooldownTime);
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
