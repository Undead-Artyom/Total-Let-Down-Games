using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneCheck : MonoBehaviour
{
    public string sceneNextlevel;
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
                pb.FinalKeyCards();

                if (pb.AllKeyCards)
                {
                    SceneManager.LoadScene(sceneNextlevel, LoadSceneMode.Single);
                }
            }
        }
    }
}
