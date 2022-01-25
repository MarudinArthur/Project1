using System.Collections;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public float WeaponFireRate { get; protected set; }
    public float WeaponRange { get; protected set; }
    public int WeaponDamage { get; protected set; }
    public bool IsReloading { get; private set; }
    protected float WeaponReloadTime { get; set; }
    protected float WeaponSpread { get; set; } 
    protected float WeaponMaxAmmo { get; set; }
    protected float WeaponCurrentAmmo { get; set; }

    public virtual void Fire() { }

    protected void WeaponReloading()
    {
        if (IsReloading)
        {
            return;
        }

        if (WeaponCurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    private IEnumerator Reload()
    {
        IsReloading = true;
        GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(true);
        yield return new WaitForSeconds(WeaponReloadTime);

        GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(false);
        WeaponCurrentAmmo = WeaponMaxAmmo;
        IsReloading = false;
    }
}