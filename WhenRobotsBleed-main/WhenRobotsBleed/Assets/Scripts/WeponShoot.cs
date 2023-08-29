using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShoot : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public bool hasGun = false;
	

	// Update is called once per frame
	void Update()
	{
		if (hasGun)
        {
			if (Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		}
		
	}


	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
