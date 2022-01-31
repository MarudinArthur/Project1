using UnityEngine;

public class BaseWeapon : Weapon
{
	public void Fire(GameObject projectile)
	{ 
		if (!isReloading) 
		{ 
			Instantiate(projectile, transform.position, transform.rotation); 
			_currentAmmo--; 
		}
	}
}