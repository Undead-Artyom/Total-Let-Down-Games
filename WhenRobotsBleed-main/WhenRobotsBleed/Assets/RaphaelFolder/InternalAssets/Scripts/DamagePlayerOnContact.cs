using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DamagePlayerOnContact : MonoBehaviour
{   
    [SerializeField]
    private int _damage;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject playerGO = collision.gameObject;
            PlayerController playerC = playerGO.GetComponent<PlayerController>();
            PlayerHealth playerH = playerGO.GetComponent<PlayerHealth>();
            playerC.KBCounter = playerC.KBTotalTime;
            if(playerGO.transform.position.x <= transform.position.x)
            {
                playerC.KnockFromRight = true;
            }
            if(playerGO.transform.position.x > transform.position.x)
            {
                playerC.KnockFromRight = false;
            }
            playerH.TakeDamage(_damage);
        }
    }
}