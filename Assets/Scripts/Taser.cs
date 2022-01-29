using System;
using TMPro;
using UnityEngine;

public class Taser : BaseWeapon
{
	[Header("Weapon Settings")]
	[SerializeField] private float _firerate = 10f;
	[SerializeField] private float _reloadTime = 4f;

	public float _range = 10f;
	public float _damage = 10f;
	public TextMeshProUGUI ammoCounter;
    
	private bool _isReloading;
	private float maxAmmo = 3f;
	private float currentAmmo;

/*
    public Taser()
	{
		WeaponFireRate = 10f;
		WeaponRange = 10f;
		WeaponDamage = 10;
		WeaponMaxAmmo = 3f;
		WeaponReloadTime = 4f;

        WeaponCurrentAmmo = WeaponMaxAmmo;
    }
*/

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