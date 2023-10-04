using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController pb = other.gameObject.GetComponent<PlayerController>();
            if (pb != null)
            {
                pb.HasAKeyCard();
                Destroy(this.gameObject);
            }
        }
    }
}
