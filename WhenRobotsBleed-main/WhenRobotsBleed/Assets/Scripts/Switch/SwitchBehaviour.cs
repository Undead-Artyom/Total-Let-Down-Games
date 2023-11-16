using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    public GameObject switch1;

    //public Sprite sp1, sp2;
    public GameObject ob1;
    public GameObject ob2;
    //public GameObject switch2;

    public GameObject thisSwitch;
    AudioSource asource;
    public AudioClip switchClip;

    public bool swtichOn;

    void Start()
    {
        thisSwitch = this.gameObject;
        //swtichOn = true;
        asource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Triggered");
        if (collision.gameObject.tag == "Bullet")
        {
            asource.PlayOneShot(switchClip, 0.8f);
            if (swtichOn)
            {
                switch1.gameObject.SetActive(false);
                //switch2.gameObject.SetActive(true);
                //GetComponent<SpriteRenderer>().sprite = sp1;
                ob1.GetComponent<SpriteRenderer>().enabled = false;
                ob2.GetComponent<SpriteRenderer>().enabled = true;
                swtichOn = false;
            }
            else if (!swtichOn)
            {
                switch1.gameObject.SetActive(true);
                //switch2.gameObject.SetActive(false);
                //GetComponent<SpriteRenderer>().sprite = sp2;
                ob1.GetComponent<SpriteRenderer>().enabled = true;
                ob2.GetComponent<SpriteRenderer>().enabled = false;
                swtichOn = true;
            }
        }
        return;
    }
}
