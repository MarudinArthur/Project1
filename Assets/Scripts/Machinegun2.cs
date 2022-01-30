using TMPro;
using UnityEngine;

public class Machinegun2 : BaseWeapon
{
	/*
	[SerializeField] protected float _firerate = 50f;
	[SerializeField] protected float _range = 10f;
	[SerializeField] protected float _damage = 1f;
	[SerializeField] protected float _reloadTime = 4f;
	[SerializeField] protected float maxAmmo = 100f;
	*/
	
	public TextMeshProUGUI ammoCounter;

	public Machinegun2()
	{
		firerate = 50f; 
		_reloadTime = 4f; 
		range = 10f; 
		damage = 1;
		maxAmmo = 100f;
        
		currentAmmo = maxAmmo;
	}

	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + currentAmmo;
	}
}