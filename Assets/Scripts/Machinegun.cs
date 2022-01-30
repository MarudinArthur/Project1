using TMPro;

public class Machinegun : BaseWeapon
{
	public TextMeshProUGUI ammoCounter;

	public Machinegun()
	{
		firerate = 40f; 
		_reloadTime = 4f; 
		range = 10f; 
		damage = 1;
		maxAmmo = 500f;
        
		currentAmmo = maxAmmo;
	}
	
	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + currentAmmo;
	}
}