using UnityEngine;
using TMPro;

public class ShotGun : Weapon
{
	public GameObject projectilePrefab;
	public TextMeshProUGUI ammoCounter;

	public ShotGun()
	{
		firerate = 30f; 
		_reloadTime = 3f; 
		range = 8f; 
		damage = 15;
		maxAmmo = 12f;
        
		currentAmmo = maxAmmo;
	}

	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + currentAmmo;
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
				currentAmmo--;
			}
		}
	}
}