using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20;
    [SerializeField] private float cooldownTime = 2.0f;

    private PlayerHealth playerHealth;
    private SimpleEnemyAI trackPatrolling;
    private bool canAttack = true;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        trackPatrolling = gameObject.GetComponent<SimpleEnemyAI>();
    }

    void Update()
    {
        if (canAttack && trackPatrolling.IsPatrolling() && Vector2.Distance(transform.position, playerHealth.transform.position) <= 1.5f)
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
