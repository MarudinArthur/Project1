using UnityEngine;
using TMPro;

public class Pistol : Weapons
{
    public GameObject projectilePrefab;
    public TextMeshProUGUI ammoCounter;

    public Pistol()
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
        if (!IsReloading)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            WeaponCurrentAmmo--;
        }
    }
}