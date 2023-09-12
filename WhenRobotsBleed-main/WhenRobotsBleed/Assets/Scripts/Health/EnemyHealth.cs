using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health = 100;

	//public GameObject deathEffect;

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("EnemyHP =" + health);

		if (health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
