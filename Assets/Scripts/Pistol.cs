using UnityEngine;
using TMPro;

public class Pistol : Weapons
{
    public GameObject porjectilePrefab;
    
    //private ParticleHolder particle;
    //private AudioSource playerAudio;
    public AudioClip soundShoot;
    private Animator _animator;
    private int _animationState;

    public TextMeshProUGUI ammoCounter;

    Pistol()
    {
        WeaponDamage = 20;
        WeaponFireRate = 10f;
        WeaponReloadTime = 3f;
        WeaponRange = 6f;
        WeaponSpread = 4f;
        WeaponMaxAmmo = 12f;
    }

    private void Start()
    {
        WeaponCurrentAmmo = WeaponMaxAmmo;

        //playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
        _animator = GameObject.Find("Player").GetComponent<Animator>();
        //particle = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();
    }

    private void Update()
    {
        WeaponReloading();

        ammoCounter.text = "Ammo: " + WeaponCurrentAmmo;
    }

    public override void Fire() 
    {
        if (!isReloading)
        {
            Instantiate(porjectilePrefab, transform.position, transform.rotation);
            WeaponCurrentAmmo--;
        }
    }
}