using UnityEngine;
using TMPro;

public class Machinegun2 : Weapons
{
	public GameObject projectilePrefab;
	public TextMeshProUGUI ammoCounter;

	public Machinegun2()
	{
		WeaponFireRate = 50f;
		WeaponRange = 10;
		WeaponDamage = 1;
		WeaponMaxAmmo = 100;
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
			Instantiate(projectilePrefab, transform.position, transform.rotation);
			WeaponCurrentAmmo--;
		}
	}
}