using TMPro;

public class Pistol : BaseWeapon
{
    public TextMeshProUGUI ammoCounter;
    private float _maxAmmo;

    public Pistol()
    { 
        firerate = 10f; 
        _reloadTime = 3f; 
        range = 6f; 
        damage = 20;
        maxAmmo = 16f;
        
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        WeaponReloading();
        ammoCounter.text = "Ammo: " + currentAmmo;
    }
}