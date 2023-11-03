using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSpawn : MonoBehaviour
{
    public GameObject hunter;
    public GameObject spawner;
    [SerializeField] private bool hunterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        hunterSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.gameObject.tag == "Player")
        {
            if (hunterSpawn)
            {
                Instantiate(hunter, spawner.transform.position, Quaternion.identity);
                hunterSpawn = false;
            }
        }
    }
}
