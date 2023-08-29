using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject[] bulletArr;
    private PlayerController playerController;
    private float cooldownTimer = 1;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && cooldownTimer > attackCooldown && playerController.canAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        bulletArr[FindBullets()].transform.position = point.position;
        bulletArr[FindBullets()].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBullets()
    {
        for (int i = 0; i < bulletArr.Length; i++)
        {
            if (!bulletArr[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}


