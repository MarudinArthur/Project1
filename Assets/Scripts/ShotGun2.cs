using TMPro;

public class ShotGun2 : BaseWeapon
{
    public TextMeshProUGUI ammoCounter;

    public ShotGun2()
    {
        WeaponDamage = 20;
        WeaponFireRate = 10f;
        WeaponReloadTime = 3f;
        WeaponRange = 6f;
        WeaponSpread = 4f;
        WeaponMaxAmmo = 32f;

        WeaponCurrentAmmo = WeaponMaxAmmo;
    }

    private void Update()
    {
        WeaponReloading();
        ammoCounter.text = "Ammo: " + WeaponCurrentAmmo;
    }
}
