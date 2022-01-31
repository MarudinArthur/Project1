using System;
using TMPro;

public class Machinegun : BaseWeapon
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