using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSwitch : MonoBehaviour
{

    public AudioClip ChaseBGM;
    private BGMControl bgmControl;

    // Start is called before the first frame update
    void Start()
    {
        bgmControl = FindObjectOfType<BGMControl>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (ChaseBGM != null)
                bgmControl.ChangeBGM(ChaseBGM);
        }
    }
}
