using TMPro;
using UnityEngine;

public class ShotGun2 : BaseWeapon
{
    public TextMeshProUGUI ammoCounter;

    public ShotGun2()
    {
        firerate = 10f; 
        _reloadTime = 3f; 
        range = 6f; 
        damage = 20;
        maxAmmo = 32f;
        maxAmmo = 16f;
        
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        WeaponReloading();
        ammoCounter.text = "Ammo: " + currentAmmo;
    }
}
