using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public KeyDetetor Kd;

    void Start()
    {
        KeyDetetor Kd = GetComponent<KeyDetetor>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Kd != null)
            {
                print("key got");
                Kd.gotKey = true;
            }

            Destroy(this.gameObject);
        }
    }
}
