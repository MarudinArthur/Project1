using System.Collections;
using UnityEngine;

public class Pistol : Weapons
{
    public GameObject porjectilePrefab;

    Pistol()
    {
        // значения свойств временные
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
        WeaponReloading();
    }

    public override void Fire()
    {
        if (!isReloading)
        {
            Instantiate(porjectilePrefab, transform.position, transform.rotation);
            WeaponCurrentAmmo--;
        }
    }

    public void TakeDamageEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemies.enemyCurrentHealth -= WeaponDamage;
        enemies.enemyHealthBar.SetHealth(enemies.enemyCurrentHealth);
    }
}