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
    public GameObject attackBoxColider;
    public SpriteRenderer swordSprite; 

    private WeponShoot _weponShoot;
    private bool _canAttack;
    public bool canAttack => _canAttack;

    void Awake(){
    
    }
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSword && _canAttack)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                _weponShoot.ChangeCanShoot(false);
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
                attackBoxColider.SetActive(false);
                swordSprite.enabled = false;
                _weponShoot.ChangeCanShoot(true);
            }

        }
    }
    public void ChangeCanAttack(bool val){
        if(val == true || val == false){
            _canAttack = val;
        }
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        attackBoxColider.SetActive(true);
        swordSprite.enabled = true;
    }
}
