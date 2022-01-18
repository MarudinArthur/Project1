using UnityEngine;
using TMPro;

public class Machinegun : Weapons
{
	public GameObject projectilePrefab;

	private ParticleHolder particle;
	private AudioSource playerAudio;
	public AudioClip soundShoot;
	public Animator _animator;
	private int _animationState;

	private GameObject player;

	public TextMeshProUGUI ammoCounter;

	Machinegun()
	{
		WeaponFireRate = 20f;
		WeaponRange = 10;
		WeaponDamage = 1;
		WeaponMaxAmmo = 500;
		WeaponReloadTime = 4f;
	}

	private void Start()
	{
		WeaponCurrentAmmo = WeaponMaxAmmo;

		playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
		_animator = GameObject.Find("Player").GetComponent<Animator>();
		particle = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();

		player = GameObject.Find("Player");
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
			float projectilePos = 0;

			for (int i = 0; i < 3; i++)
			{
				projectilePos -= 2.5f;
				Vector3 offset = new Vector3(player.transform.position.x, player.transform.position.y, projectilePos);
				Instantiate(projectilePrefab, offset, transform.rotation);

				WeaponCurrentAmmo--;
			}
		}
	}
}