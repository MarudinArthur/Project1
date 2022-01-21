using UnityEngine;
using TMPro;

public class ShotGun : Weapons
{
	public GameObject projectilePrefab;
	public TextMeshProUGUI ammoCounter;

	public ShotGun()
	{
		WeaponFireRate = 30f;
		WeaponRange = 8f;
		WeaponDamage = 15;
		WeaponMaxAmmo = 12f;
		WeaponReloadTime = 3f;

		WeaponCurrentAmmo = WeaponMaxAmmo;
	}

	private void Update()
	{
		WeaponReloading();

		ammoCounter.text = "Ammo: " + WeaponCurrentAmmo;
	}

	public override void Fire()
	{
		WeaponSpread = -20f;

		if (!isReloading)
        {
			for (int i = 0; i < 3; i++)
			{
				WeaponSpread += 10;
				Vector3 offset = new Vector3(0, WeaponSpread, 0);
				Instantiate(projectilePrefab, transform.position, Quaternion.Euler(offset));

				WeaponCurrentAmmo--;
			}
		}
	}
}