using UnityEngine;

public class BaseWeapon : Weapon
{
	[SerializeField] protected float _firerate;
	[SerializeField] protected float _range;
	[SerializeField] protected float _damage;
	[SerializeField] protected float _reloadTime;
	[SerializeField] protected float _spread;
    
	protected bool _isReloading;
	protected float maxAmmo;
	protected float currentAmmo;
	
	public void Fire(GameObject projectile)
	{ 
		if (!_isReloading) 
		{ 
			Instantiate(projectile, transform.position, transform.rotation); 
			currentAmmo--; 
		}
	}
}