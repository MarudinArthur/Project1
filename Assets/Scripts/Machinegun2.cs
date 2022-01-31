﻿using System;
using TMPro;
using UnityEngine;

public class Machinegun2 : BaseWeapon
{
	public TextMeshProUGUI ammoCounter;

	private void Start()
	{
		_currentAmmo = _maxAmmo;
	}

	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + _currentAmmo;
	}
}