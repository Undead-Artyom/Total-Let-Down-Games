using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDetetor : MonoBehaviour
{
    [SerializeField]
    private string _colliderScript;

    [SerializeField]
    private UnityEvent _colliderEntered;

    [SerializeField]
    private UnityEvent _colliderExit;

    [SerializeField] public bool gotKey = false; 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gotKey)
        {
            if (col.gameObject.GetComponent(_colliderScript))
            {
                _colliderEntered?.Invoke();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (gotKey)
        {
            if (col.gameObject.GetComponent(_colliderScript))
            {
                _colliderExit?.Invoke();
            }
        }
    }

}
