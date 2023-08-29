using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private GameObject attackArea = default;
    public bool hasSword = false; 

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public BoxCollider2D attackBoxColider;
    public SpriteRenderer swordSprite; 
    

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSword)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Attack();
            }
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                attackBoxColider.enabled = false;
                swordSprite.enabled = false;
            }

        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        attackBoxColider.enabled = true;
        swordSprite.enabled = true;
    }
}
