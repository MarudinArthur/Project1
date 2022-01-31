using TMPro;

public class Taser : BaseWeapon
{
	public TextMeshProUGUI ammoCounter;

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