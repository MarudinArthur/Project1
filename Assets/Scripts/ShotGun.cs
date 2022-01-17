using UnityEngine;
using TMPro;

public class ShotGun : Weapons
{
	public GameObject projectilePrefab;
	private Enemy enemy;

	private ParticleHolder particle;
	private AudioSource playerAudio;
	public AudioClip soundShoot;
	public Animator _animator;
	private int _animationState;
	public TextMeshProUGUI ammoCounter;

	ShotGun()
	{
		// значения свойств временные
		WeaponFireRate = 20;
		WeaponRange = 5f;
		WeaponDamage = 20;
		WeaponMaxAmmo = 12f;
		WeaponSpread = 2;
		WeaponReloadTime = 4;
		
	}

	private void Start()
	{
		WeaponCurrentAmmo = WeaponMaxAmmo;

		playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
		_animator = GameObject.Find("Player").GetComponent<Animator>();
		particle = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();

		// говно-способ получить ссылку на этот скрипт, но пока лучше не придумал:
		enemy = GameObject.Find("Enemy Holder").transform.GetChild(0).GetComponent<Enemy>();
	}

	private void Update()
	{
		WeaponReloading();

		ammoCounter.text = "Ammo: " + WeaponCurrentAmmo;
	}

	public override void Fire()
	{
		int projectilePos = -10;

		if (!isReloading)
        {
			for (int i = 0; i < 3; i++)
			{
				projectilePos += 5;
				Vector3 offset = new Vector3(0, projectilePos, 0);
				GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.Euler(offset));
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

	public void TakeDamageEnemy(int currentHealth)
	{
		currentHealth -= WeaponDamage;
		Debug.Log(currentHealth);
		enemy.enemyHealthBar.SetHealth(currentHealth);
	}
}