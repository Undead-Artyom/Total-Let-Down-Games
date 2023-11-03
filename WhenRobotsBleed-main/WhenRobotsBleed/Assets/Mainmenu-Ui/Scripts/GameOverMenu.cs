using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{

    public GameObject GameOverScreen; //for gameoverscreen

    public GameObject player;

     void Start()
    {
        player = GameObject.Find("Player");
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        player.SetActive(false);
    }
    public void GameOverStop()
    {
        GameOverScreen.SetActive(false);
        player.SetActive(true);
    }
}

