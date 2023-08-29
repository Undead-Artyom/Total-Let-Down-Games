using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject[] switches;

    [SerializeField] public GameObject exitDoor;

    int noOfSwitches = 0;

    [SerializeField]
    Text switchCount;

    /*public static GameManager instance;
    public int score = 0;*/

    void Start()
    {
        GetNoOfSwitches();
    }

   public int GetNoOfSwitches()
    {
        int x = 0;

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<boxbox3>().isOn == false)
                    x++;
            else if(switches[i].GetComponent<boxbox3>().isOn == true)
                noOfSwitches--;
        }

        noOfSwitches = x;

        return noOfSwitches;
    }

    /*  public void GetExitDoorState()
      {
          if (noOfSwitches <= 0)
          {
              exitDoor.GetComponent<exitDoor>().OpenDoor();
          }

      }

      void Update()
      {
          switchCount.text = GetNoOfSwitches().ToString();

          GetExitDoorState();
      }*/

    /*public void AddScore(int points)
    {
        // Add points to the player's score
        score += points;
    }*/
}
