using System;
using TMPro;
using UnityEngine;

public class Taser : BaseWeapon
{
	/*
	[Header("Weapon Settings")]
	[SerializeField] private float _firerate = 10f;
	[SerializeField] private float _reloadTime = 4f;

	public float _range = 10f;
	public int damage = 10;
	private bool _isReloading;
	private float maxAmmo = 3f;
	private float currentAmmo;
	*/
	public TextMeshProUGUI ammoCounter;
	
    public Taser()
	{
		firerate = 10f;
		range = 10f;
		damage = 10;
		maxAmmo = 3f;
		_reloadTime = 4f;

        currentAmmo = maxAmmo;
    }

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