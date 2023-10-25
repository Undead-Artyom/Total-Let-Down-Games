using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;

    public GameObject thisSwitch;
    AudioSource asource;
    public AudioClip switchClip;

    [SerializeField] bool swtichOn;

    void Start()
    {
        thisSwitch = this.gameObject;
        swtichOn = true;
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
                switch2.gameObject.SetActive(true);
                swtichOn = false;
            }
            else if (!swtichOn)
            {
                switch1.gameObject.SetActive(true);
                switch2.gameObject.SetActive(false);
                swtichOn = true;
            }
        }
        return;
    }
}
