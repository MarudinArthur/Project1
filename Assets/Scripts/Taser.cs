using UnityEngine;
using TMPro;

public class Taser : Weapons
{
    public GameObject porjectilePrefab;

    private ParticleHolder particle;
    private AudioSource playerAudio;
    public AudioClip soundShoot;
    public Animator _animator;
    private int _animationState;

    public TextMeshProUGUI ammoCounter;

    Taser()
	{
		// значения свойств временные
		WeaponFireRate = 10;
		WeaponRange = 10;
		WeaponDamage = 10;
		WeaponMaxAmmo = 3;
		WeaponSpread = 2;
		WeaponReloadTime = 4;
	}

	public void Start()
	{
        WeaponCurrentAmmo = WeaponMaxAmmo;

        playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
        _animator = GameObject.Find("Player").GetComponent<Animator>();
        particle = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();

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

            _animationState = 4;
            playerAudio.PlayOneShot(soundShoot, 1.0f);
            particle.PlayParticle(2, gameObject.transform.position);

            if (transform.position.z > WeaponRange)
                Destroy(gameObject);
        }
        else
        {
            _animationState = 0;
        }
        _animator.SetInteger("state", _animationState);
    }
}