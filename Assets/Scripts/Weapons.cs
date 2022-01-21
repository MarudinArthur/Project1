using System.Collections;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public float WeaponFireRate { get; set; }
    public float WeaponRange { get; set; }
    public int WeaponDamage { get; set; }
    protected float WeaponReloadTime { get; set; }
    protected float WeaponSpread { get; set; } 
    protected float WeaponMaxAmmo { get; set; }
    protected float WeaponCurrentAmmo { get; set; }
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