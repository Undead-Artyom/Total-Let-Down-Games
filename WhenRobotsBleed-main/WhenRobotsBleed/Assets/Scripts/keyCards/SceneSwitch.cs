using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneNextlevel;
    public bool TLevel = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        //quick test to load next Scene trigger 
        //SceneManager.LoadScene(4);
        //SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

        if (other.gameObject.tag == "Player")
        {
            PlayerController pb = other.gameObject.GetComponent<PlayerController>();
            if (pb != null)
            {
                if (pb.hasKeyCard)
                {
                    pb.KeyCardUsed();
                    SceneManager.LoadScene(sceneNextlevel, LoadSceneMode.Single);
                    if (TLevel)
                    {
                        //pb.KeyCardUsedT();
                    }
                }
            }
        }
    }
}
