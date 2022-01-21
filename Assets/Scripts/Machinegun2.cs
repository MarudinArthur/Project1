using UnityEngine;
using TMPro;

public class Machinegun2 : Weapons
{
    public GameObject porjectilePrefab;
    public TextMeshProUGUI ammoCounter;

    Machinegun2()
    {
        WeaponDamage = 20;
        WeaponFireRate = 10f;
        WeaponReloadTime = 3f;
        WeaponRange = 6f;
        WeaponSpread = 4f;
        WeaponMaxAmmo = 32f;

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
