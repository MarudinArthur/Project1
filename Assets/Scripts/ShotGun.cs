using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapons
{
	public GameObject porjectilePrefab;

	ShotGun()
	{
		// значения свойств временные
		WeaponFireRate = 20;
		WeaponRange = 10;
		WeaponDamage = 20;
		WeaponMaxAmmo = 3;
		WeaponSpread = 2;
		WeaponReloadTime = 4;
	}

	public override void Fire()
	{
		Debug.Log("ShotGun Fire! ");
	}
}