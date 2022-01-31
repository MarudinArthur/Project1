using System;
using UnityEngine;
using TMPro;

public class ShotGun : Weapon
{
	public GameObject projectilePrefab;
	public TextMeshProUGUI ammoCounter;

	private void Start()
	{
		_currentAmmo = _maxAmmo;
	}

	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + _currentAmmo;
	}

	public override void Fire()
	{
		_spread = -20f;

		if (!isReloading)
        {
			for (var i = 0; i < 3; i++)
			{
				_spread += 10;
				var offset = new Vector3(0, _spread, 0);
				Instantiate(projectilePrefab, transform.position, Quaternion.Euler(offset));
				_currentAmmo--;
			}
		}
	}
}