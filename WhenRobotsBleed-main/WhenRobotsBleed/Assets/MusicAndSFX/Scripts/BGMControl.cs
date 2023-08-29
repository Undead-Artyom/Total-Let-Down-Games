using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMControl : MonoBehaviour
{
    
    public AudioSource LevelBGM;
   

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeBGM(AudioClip music)
    {

        if (LevelBGM.clip.name == music.name)
            return;

        LevelBGM.Stop();
        LevelBGM.clip = music;
        LevelBGM.Play();
    }
}
