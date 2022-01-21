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
			float projectilePos = 0;

			for (int i = 0; i < 3; i++)
			{
				projectilePos -= 2.5f;
				Vector3 offset = new Vector3(transform.position.x, transform.position.y, projectilePos);
				Instantiate(projectilePrefab, offset, transform.rotation);

				WeaponCurrentAmmo--;
			}
		}
	}
}