﻿using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{ 	
    [Header("Weapon Settings")]
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected float _spread;
    [SerializeField] protected float maxAmmo;
    [SerializeField] protected float currentAmmo;

    public int damage;
    public float firerate;
    public float range;
    public bool isReloading;

    public virtual void Fire() { }

    protected void WeaponReloading()
    {
        if (isReloading)
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
        isReloading = true;

        var reloadText = GameObject.Find("Canvas").transform.GetChild(13);
        reloadText.gameObject.SetActive(true);
        yield return new WaitForSeconds(_reloadTime);

        reloadText.gameObject.SetActive(false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}