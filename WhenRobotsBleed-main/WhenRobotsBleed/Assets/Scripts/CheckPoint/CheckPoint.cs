using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private PlayerHealth cp; 

    void Start()
    {
        //cp = GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //gm.lastCheckPointPos = transform.position;
            Debug.Log("CheckPointTriggred!");
           // cp.respawnPoint = transform;
        }
    }
}
