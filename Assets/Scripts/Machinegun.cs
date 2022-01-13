using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Weapons
{
	public GameObject porjectilePrefab;

	Machinegun()
	{
		// значения свойств временные
		WeaponFireRate = 10;
		WeaponRange = 10;
		WeaponDamage = 20;
		WeaponMaxAmmo = 3;
		WeaponSpread = 2;
		WeaponReloadTime = 4;
	}

	public override void Fire()
	{
		Debug.Log("Machinegun Fire! ");
	}
}