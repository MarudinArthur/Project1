using System.Collections;
using UnityEngine;

public class Pistol : Weapons
{
    public GameObject porjectilePrefab;
    [HideInInspector] public bool isReloading;

    Pistol()
    {
        WeaponDamage = 10; 
        WeaponFireRate = 10;
        WeaponRange = 2;
        WeaponReloadTime = 3f; // done
        WeaponSpread = 3f;
        WeaponMaxAmmo = 6f; // done
    }

    private void Start()
    {
        WeaponCurrentAmmo = WeaponMaxAmmo;
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (WeaponCurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    public override void Fire()
    {
        if (!isReloading)
        {
            Instantiate(porjectilePrefab, transform.position, transform.rotation);
            WeaponCurrentAmmo--;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(true);
        yield return new WaitForSeconds(WeaponReloadTime);

        GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(false);
        WeaponCurrentAmmo = WeaponMaxAmmo;
        isReloading = false;
    }
}