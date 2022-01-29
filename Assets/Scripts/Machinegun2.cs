using TMPro;

public class Machinegun2 : BaseWeapon
{
	public TextMeshProUGUI ammoCounter;

	public Machinegun2()
	{
		WeaponFireRate = 50f;
		WeaponRange = 10;
		WeaponDamage = 1;
		WeaponMaxAmmo = 100;
		WeaponReloadTime = 4f;

		WeaponCurrentAmmo = WeaponMaxAmmo;
	}

	private void Update()
	{
		WeaponReloading();
		ammoCounter.text = "Ammo: " + WeaponCurrentAmmo;
	}
}