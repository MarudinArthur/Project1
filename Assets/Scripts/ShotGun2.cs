using TMPro;

public class ShotGun2 : BaseWeapon
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
