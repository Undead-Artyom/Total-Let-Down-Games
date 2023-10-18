using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public string firstlevel;


    public void StartGame()
    {
        SceneManager.LoadScene(firstlevel, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}