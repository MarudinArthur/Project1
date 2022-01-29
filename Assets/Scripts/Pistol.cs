using System;
using TMPro;
using UnityEngine;

public class Pistol : BaseWeapon
{ 
    [Header("Weapon Settings")]
    [SerializeField] private float _firerate = 10f;
    [SerializeField] private float _reloadTime = 3f;

    public float _range = 6f;
    public float _damage = 20f;
    public TextMeshProUGUI ammoCounter;
    
    private bool _isReloading;
    private float maxAmmo;
    private float currentAmmo;
    
    /*public Pistol()
    {
        WeaponDamage = 20;
        WeaponFireRate = 10f;
        WeaponReloadTime = 3f;
        WeaponRange = 6f;
        WeaponMaxAmmo = 32f;

        WeaponCurrentAmmo = WeaponMaxAmmo;
    }*/
    

    private void Update()
    {
        WeaponReloading();
        ammoCounter.text = "Ammo: " + currentAmmo;
    }
}