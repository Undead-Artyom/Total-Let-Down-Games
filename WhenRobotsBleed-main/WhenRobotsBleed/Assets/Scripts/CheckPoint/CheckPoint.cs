using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    PlayerHealth cp;
    public Transform lastCheckPont;
    public GameObject checkPontPrefab;

    void Start()
    {
        lastCheckPont = GetComponent<Transform>();
        cp = GetComponent<PlayerHealth>();
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        lastCheckPont.position = checkPontPrefab.gameObject.transform.position;
        if(other.gameObject.tag == "Player")
        {
            //gm.lastCheckPointPos = transform.position;
            Debug.Log("CheckPointTriggred!" + checkPontPrefab);
            if(cp != null)
            {
                cp.respawnPoint = lastCheckPont;
            }
        }
    }*/
}
