using UnityEngine;

public class BaseWeapon : Weapon
{
	[SerializeField] protected GameObject projectile;

	public override void Fire()
	{
		Instantiate(projectile, transform.position, transform.rotation);
		currentAmmo--;
	}
}