using UnityEngine;
using TMPro;

public class Taser : Weapons
{
    public GameObject porjectilePrefab;
    public TextMeshProUGUI ammoCounter;

    public Taser()
	{
		WeaponFireRate = 10f;
		WeaponRange = 10f;
		WeaponDamage = 10;
		WeaponMaxAmmo = 3f;
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
            Instantiate(porjectilePrefab, transform.position, transform.rotation);
            WeaponCurrentAmmo--;
        }
    }
}