using UnityEngine;
using TMPro;

public class ShotGun : Weapons
{
	public GameObject projectilePrefab;

	private ParticleHolder particle;
	private AudioSource playerAudio;
	public AudioClip soundShoot;
	public Animator _animator;
	private int _animationState;

	public TextMeshProUGUI ammoCounter;

	ShotGun()
	{
		WeaponFireRate = 30f;
		WeaponRange = 8f;
		WeaponDamage = 15;
		WeaponMaxAmmo = 12f;
		WeaponReloadTime = 3f;
	}

	private void Start()
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
		WeaponSpread = -20f;

		if (!isReloading)
        {
			for (int i = 0; i < 3; i++)
			{
				WeaponSpread += 10;
				Vector3 offset = new Vector3(0, WeaponSpread, 0);
				Instantiate(projectilePrefab, transform.position, Quaternion.Euler(offset));

				WeaponCurrentAmmo--;
			}
			_animationState = 4;
			playerAudio.PlayOneShot(soundShoot, 1.0f);
			particle.PlayParticle(2, gameObject.transform.position);
		}
		else
		{
			_animationState = 0;
		}
		_animator.SetInteger("state", _animationState);
	}
}