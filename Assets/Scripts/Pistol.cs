using UnityEngine;
using TMPro;

public class Pistol : Weapons
{
    public GameObject porjectilePrefab;
    private Enemy enemy;
    
    private ParticleHolder particle;
    private AudioSource playerAudio;
    public AudioClip soundShoot;
    public Animator _animator;
    private int _animationState;

    public TextMeshProUGUI ammoCounter;


    Pistol()
    {
        // значения свойств временные
        WeaponDamage = 30; // done
        WeaponFireRate = 10; // done
        WeaponReloadTime = 3f; // done
        WeaponRange = 7f;
        WeaponSpread = 3f;
        WeaponMaxAmmo = 6f; // done
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
        if (!isReloading)
        {
            GameObject projectile = Instantiate(porjectilePrefab, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * WeaponFireRate, ForceMode.Impulse);

            WeaponCurrentAmmo--;

            _animationState = 4;
            playerAudio.PlayOneShot(soundShoot, 1.0f);
            particle.PlayParticle(2, gameObject.transform.position);

            if (projectile.transform.position.z > WeaponRange)
                Destroy(gameObject);
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