using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShoot : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public bool hasGun = false;
	private Animator _playerAnimator;
	private bool _isShooting = false;

	void Awake(){
		_playerAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (hasGun)
        {
			if (Input.GetButtonDown("Fire1") && _isShooting == false)
			{
				var currentState = _playerAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash;
				_isShooting = true;
				StartCoroutine(Shoot(currentState));
			}
		}
	}


	private IEnumerator Shoot(int intendedState)
	{
		_playerAnimator.Play("Character_Shoot");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		yield return new WaitForSeconds(0.4f);
		_playerAnimator.Play(intendedState);
		_isShooting = false;
	}
}
