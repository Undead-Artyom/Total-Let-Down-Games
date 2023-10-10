using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstlevel;

    public GameObject optionsScreen;
    public GameObject controlsScreen;
   

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */
    

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
    

    public void StartGame()
    {
        SceneManager.LoadScene(firstlevel, LoadSceneMode.Single);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
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
