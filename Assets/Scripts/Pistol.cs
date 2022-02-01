using TMPro;
using UnityEngine;

public class Pistol : BaseWeapon
{
    [SerializeField] private TextMeshProUGUI ammoCounter;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    
    private void Update()
    {
        WeaponReloading();
        ammoCounter.text = "Ammo: " + currentAmmo;
    }
}