using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Weapons
{
	public GameObject projectilePrefab;
	private Enemy enemy;

	private ParticleHolder particle;
	private AudioSource playerAudio;
	public AudioClip soundShoot;
	public Animator _animator;
	private int _animationState;

	Machinegun()
	{
		// значения свойств временные
		WeaponFireRate = 20;
		WeaponRange = 10;
		WeaponDamage = 1;
		WeaponMaxAmmo = 500;
		WeaponSpread = -15;
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
	}

	public override void Fire()
	{
		Debug.Log("Machinegun Fire! ");

		if (!isReloading)
		{
			float projectilePos = 0;

			for (int i = 0; i < 3; i++)
			{
				projectilePos -= 3f;
				Vector3 offset = new Vector3(transform.position.x, transform.position.y, projectilePos);
				GameObject.Instantiate(projectilePrefab, offset, transform.rotation);
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