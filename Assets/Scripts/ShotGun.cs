using UnityEngine;

public class ShotGun : Weapons
{
	public GameObject projectilePrefab;
	private Enemy enemy;

	ShotGun()
	{
		// значения свойств временные
		WeaponFireRate = 20;
		WeaponRange = 5f;
		WeaponDamage = 20;
		WeaponMaxAmmo = 12f;
		WeaponSpread = 2;
		WeaponReloadTime = 4;
	}

	private void Start()
	{
		WeaponCurrentAmmo = WeaponMaxAmmo;

		// говно-способ получить ссылку на этот скрипт, но пока лучше не придумал:
		enemy = GameObject.Find("Enemy Holder").transform.GetChild(0).GetComponent<Enemy>();
	}

	private void Update()
	{
		WeaponReloading();
	}

	public override void Fire()
	{
		int projectilePos = -10;

		if (!isReloading)
        {
			for (int i = 0; i < 3; i++)
			{
				projectilePos += 5;
				Vector3 offset = new Vector3(0, projectilePos, 0);
				GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.Euler(offset));
				WeaponCurrentAmmo--;
			}
		}
	}

	public void TakeDamageEnemy(int currentHealth)
	{
		currentHealth -= WeaponDamage;
		Debug.Log(currentHealth);
		enemy.enemyHealthBar.SetHealth(currentHealth);
	}
}