using UnityEngine;
using TMPro;

public class Machinegun : Weapons
{
	public GameObject projectilePrefab;
	public TextMeshProUGUI ammoCounter;

	public Machinegun()
	{
		WeaponFireRate = 40f;
		WeaponRange = 10;
		WeaponDamage = 1;
		WeaponMaxAmmo = 500;
		WeaponReloadTime = 4f;

		WeaponCurrentAmmo = WeaponMaxAmmo;
	}

	private void Update()
	{
		WeaponReloading();

		ammoCounter.text = "Ammo: " + WeaponCurrentAmmo;
	}

	public override void Fire()
	{
		if (!isReloading)
        {
			if (!isReloading)
			{
				Instantiate(projectilePrefab, transform.position, transform.rotation);
				WeaponCurrentAmmo--;
			}
		}
	}
}