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

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent(_colliderScript))
        {
            _colliderEntered?.Invoke();
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.GetComponent(_colliderScript))
        {
            _colliderExit?.Invoke();
        }
    }

}
