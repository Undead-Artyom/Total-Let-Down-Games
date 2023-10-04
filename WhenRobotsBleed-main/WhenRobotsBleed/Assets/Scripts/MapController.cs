using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    private bool isPaused = false;
    private string currentSceneName;
    private GameObject mapPanel; // Reference to the UI panel

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        mapPanel = GameObject.Find("Maps");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }
    }

    private void ToggleMap()
    {
        isPaused = !isPaused;

        foreach (Transform child in transform)
        {
            // Check if the child's name matches the current scene name
            if (child.gameObject.name == currentSceneName)
            {
                child.gameObject.SetActive(isPaused); // Show or hide the map
            }
        }

        if (mapPanel != null)
        {
            // Show or hide the UI panel
            mapPanel.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Time.timeScale = 1; // Unpause the game
        }
    }
}