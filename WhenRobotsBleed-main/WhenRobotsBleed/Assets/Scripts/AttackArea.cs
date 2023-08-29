using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 20;

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Debug.Log("enemy take melee" + damage);
		}

	}
}
