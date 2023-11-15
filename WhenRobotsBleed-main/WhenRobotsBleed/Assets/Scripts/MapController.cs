using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GameObject largeMapRawObject; // Reference to the LargeMapRaw GameObject, assign in the Unity Editor

    private bool isPaused = false;
    private Scene currentScene;
    private GameObject largeMapRawGameObject;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        // Assuming the RawImage component is directly on the same GameObject as this script
        largeMapRawGameObject = GetComponentInChildren<RawImage>(true)?.gameObject; // 'true' includes inactive GameObjects

        // Set the initial state
        SetMapState();
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

        // Enable or disable the RawImage GameObject based on the scene and isPaused
        if (largeMapRawGameObject != null)
        {
            bool enableMap = currentScene == SceneManager.GetActiveScene() && isPaused;
            largeMapRawGameObject.SetActive(enableMap);

            Debug.Log("RawImage GameObject Enabled: " + enableMap);
        }
        else
        {
            Debug.LogError("RawImage GameObject not found. Make sure it's added to the UI GameObject.");
        }

        // Enable or disable the Tilemap based on the scene name
        ToggleTilemap(currentScene.name, isPaused);

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Time.timeScale = 1; // Unpause the game
        }
    }

    // Set the initial state of the map based on the 'isPaused' variable
    private void SetMapState()
    {
        // Enable or disable the RawImage GameObject based on the scene and isPaused
        if (largeMapRawGameObject != null)
        {
            bool enableMap = currentScene == SceneManager.GetActiveScene() && isPaused;
            largeMapRawGameObject.SetActive(enableMap);

            Debug.Log("Initial RawImage GameObject State: " + enableMap);
        }
        else
        {
            Debug.LogError("RawImage GameObject not found. Make sure it's added to the UI GameObject.");
        }
    }

    // Toggle the Tilemap based on the scene name
    private void ToggleTilemap(string sceneName, bool enable)
    {
        Transform mapRoomContainer = transform.Find("MapRoomContainer"); // Assuming the grid is named "MapRoomContainer", adjust as needed

        if (mapRoomContainer != null)
        {
            Transform tilemapTransform = mapRoomContainer.Find(sceneName); // Assuming the Tilemap GameObject has the same name as the scene, adjust as needed

            if (tilemapTransform != null)
            {
                Tilemap tilemap = tilemapTransform.GetComponent<Tilemap>();
                if (tilemap != null)
                {
                    tilemap.gameObject.SetActive(enable);
                }
            }
        }
    }
}


    // Toggle the Tilemap based on the scene name
    /*private void ToggleTilemap(string sceneName, bool enable)
    {
        Transform mapRoomContainer = transform.Find("MapRoomContainer"); // Assuming the grid is named "MapRoomContainer", adjust as needed

        if (mapRoomContainer != null)
        {
            Transform tilemapTransform = mapRoomContainer.Find(sceneName); // Assuming the Tilemap GameObject has the same name as the scene, adjust as needed

            if (tilemapTransform != null)
            {
                Tilemap tilemap = tilemapTransform.GetComponent<Tilemap>();
                if (tilemap != null)
                {
                    tilemap.gameObject.SetActive(enable);
                }
            }
        }
    }*/

