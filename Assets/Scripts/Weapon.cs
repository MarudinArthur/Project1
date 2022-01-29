using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _firerate;
    [SerializeField] protected float _range;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected float _spread;
    
    protected bool _isReloading;
    protected float maxAmmo;
    protected float currentAmmo;

    public virtual void Fire() { }

    protected void WeaponReloading()
    {
        if (_isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;

        var reloadText = GameObject.Find("Canvas").transform.GetChild(13);
        reloadText.gameObject.SetActive(true);
        yield return new WaitForSeconds(_reloadTime);

        reloadText.gameObject.SetActive(false);
        currentAmmo = maxAmmo;
        _isReloading = false;
    }
}