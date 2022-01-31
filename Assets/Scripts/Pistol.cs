using TMPro;

public class Pistol : BaseWeapon
{
    public TextMeshProUGUI ammoCounter;

    private void Update()
    {
        WeaponReloading();
        ammoCounter.text = "Ammo: " + _currentAmmo;
    }
}