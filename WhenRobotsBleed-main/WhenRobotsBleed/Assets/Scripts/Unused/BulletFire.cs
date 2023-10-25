using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	//public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Debug.Log("enemy take" + damage);
		}

		//Instantiate(impactEffect, transform.position, transform.rotation);

		/*if(hitInfo.gameObject.tag == "Ground" || hitInfo.gameObject.tag == "enemy")
		{

		}*/
        Destroy(this.gameObject);
    }
}
