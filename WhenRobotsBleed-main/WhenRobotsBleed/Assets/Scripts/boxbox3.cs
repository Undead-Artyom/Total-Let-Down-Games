using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxbox3 : MonoBehaviour
{
    [SerializeField]
    public GameObject switchOn;

    [SerializeField]
    public GameObject switchOff;

    public bool isOn = false;

    void Start()
    {
        // set the switch to off sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff.GetComponent<SpriteRenderer>().sprite;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //set the switch to one sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOn.GetComponent<SpriteRenderer>().sprite;

        //set the isOn to true when triggered
        isOn = true;
    }
}