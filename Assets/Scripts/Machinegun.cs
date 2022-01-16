using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Weapons
{
	public GameObject projectilePrefab;

	Machinegun()
	{
		// значения свойств временные
		WeaponFireRate = 20;
		WeaponRange = 10;
		WeaponDamage = 20;
		WeaponMaxAmmo = 3;
		WeaponSpread = -10;
		WeaponReloadTime = 4;
	}

	public override void Fire()
	{
		Debug.Log("Machinegun Fire! ");

		float projectilePos = 0;

		for (int i = 0; i < 6; i++)
		{
			projectilePos -= 1.5f;
			Vector3 offset = new Vector3(transform.position.x, transform.position.y, projectilePos);
			GameObject.Instantiate(projectilePrefab, offset, transform.rotation);
			WeaponCurrentAmmo--;
		}
	}
}