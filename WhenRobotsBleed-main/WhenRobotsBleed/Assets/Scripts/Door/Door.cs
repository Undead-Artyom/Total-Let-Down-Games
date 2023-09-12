using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"open")]
    public void Open()
    {
        _animator.SetTrigger(name: "open");
    }
}
