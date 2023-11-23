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
	private PlayerAtack _playerAtack;
	private bool _canShoot = true;
	public bool canShoot => _canShoot;

	private float _shootTime = 0.4f;
	public float shootTime => _shootTime;

	void Awake(){
		_playerAnimator = GetComponent<Animator>();
		_playerAtack = GetComponent<PlayerAtack>();
	}

	// Update is called once per frame
	void Update()
	{
		if (hasGun && _canShoot)
        {
			if (Input.GetButtonDown("Fire1") && _isShooting == false)
			{
				var currentState = _playerAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash;
				_isShooting = true;
				_playerAtack.ChangeCanAttack(false);
				StartCoroutine(Shoot(currentState));
			}
		}
	}

	public void ChangeCanShoot(bool val){
        if(val == true || val == false){
            _canShoot = val;
        }
    }

	private IEnumerator Shoot(int intendedState)
	{
		_playerAnimator.Play("Character_Shoot");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		yield return new WaitForSeconds(_shootTime);
		_playerAnimator.Play(intendedState);
		_isShooting = false;
		_playerAtack.ChangeCanAttack(true);
	}
}
