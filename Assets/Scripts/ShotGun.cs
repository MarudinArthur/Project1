using UnityEngine;
using TMPro;

public class ShotGun : Weapon
{
	[SerializeField] private float _spread = -20f;

	public GameObject projectilePrefab;
	public TextMeshProUGUI ammoCounter;

	private void Start()
	{
		currentAmmo = maxAmmo;
	}

	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + currentAmmo;
	}

	public override void Fire()
	{
		if (!isReloading)
        {
	        _spread = -20;
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