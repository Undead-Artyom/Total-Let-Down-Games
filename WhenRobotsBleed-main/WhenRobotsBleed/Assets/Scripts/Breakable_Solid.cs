using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Solid : MonoBehaviour
{
	public float time;

	void Start()
	{

	}

	void Update()
	{

	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Sword") //replace player with projectile
		{
			Destroy(gameObject, time);
			//Debug.Log("box is hitColl");
		}
	}
    
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Sword")
        {
			Destroy(gameObject, time);
			//Debug.Log("box is hit");
		}
    }
};