using UnityEngine;

public class Pistol : Weapons
{
    public GameObject porjectilePrefab;
    private Enemy enemy;

    Pistol()
    {
        // значения свойств временные
        WeaponDamage = 30; // done
        WeaponFireRate = 10; // done
        WeaponRange = -3.5f; // done
        WeaponReloadTime = 3f; // done
        WeaponSpread = 3f;
        WeaponMaxAmmo = 6f; // done
    }

    private void Start()
    {
        WeaponCurrentAmmo = WeaponMaxAmmo;

        // говно-способ получить ссылку на этот скрипт, но пока лучше не придумал:
        enemy = GameObject.Find("Enemy Holder").transform.GetChild(0).GetComponent<Enemy>();
    }

    private void Update()
    {
        WeaponReloading();
        porjectilePrefab.transform.Translate(Vector3.forward * WeaponFireRate * Time.deltaTime);
    }

    public override void Fire() 
    {
        if (!isReloading)
        {
            Instantiate(porjectilePrefab, transform.position, transform.rotation);
            WeaponCurrentAmmo--;
        }
    }

    public void TakeDamageEnemy(int currentHealth)
    {
        currentHealth -= WeaponDamage;
        Debug.Log(currentHealth);
        enemy.enemyHealthBar.SetHealth(currentHealth);
    }
}