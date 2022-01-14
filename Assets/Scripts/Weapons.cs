using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    //public enum type { pistol, shotgun, machinegun, taser };

    public float WeaponFireRate { get; set; } //скорость стрельбы
    public float WeaponRange { get; set; } // дальность
    public int WeaponDamage { get; set; } //урон
    protected float WeaponReloadTime { get; set; } //перезарядка
    protected float WeaponSpread { get; set; } //разброс стрельбы
    protected float WeaponMaxAmmo { get; set; } // максимальная обойма
    protected float WeaponCurrentAmmo { get; set; } // текущая обойма
    public bool isReloading { get; set; }

    public virtual void Fire() { }

    protected void WeaponReloading()
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

    protected IEnumerator Reload()
    {
        isReloading = true;
        GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(true);
        yield return new WaitForSeconds(WeaponReloadTime);

        GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(false);
        WeaponCurrentAmmo = WeaponMaxAmmo;
        isReloading = false;
    }
}