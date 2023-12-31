using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject optionsScreen;

    public GameObject controlsScreen;

    public GameObject pauseMenuUI;

    //public GameObject GameOverScreen; //for gameoverscreen

   // public GameObject player;

     void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                //optionsScreen.SetActive(false);
                //controlsScreen.SetActive(false);
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        Debug.Log("Loading menu...");
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void OpenControls()
    {
        controlsScreen.SetActive(true);
    }

    public void CloseControls()
    {
        controlsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}

