using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [HideInInspector] public int currentHealth;

    public int maxHealth = 100;
    public HealthBar healthBar;
    public Image fill;
    public AudioClip soundPistol;
    public AudioClip soundShotGun;
    public AudioClip soundMachinegun;
    public AudioClip soundTaser;
    public AudioClip soundChangeSkin;
    public AudioClip soundGetPowerUps;
    private Animator _animator;
    public ParticleSystem particleShoot;
    private ParticleHolder particleHolder;

    private GameManager _gameManager;
    private SwitchWeapon switchWeapon;
    private Powerups _powerUps;
    private AudioSource playerAudio;

    private Pistol _pistol;
    private ShotGun _shotGun;
    private Machinegun _machinegun;
    private Taser _taser;

    private float _horizontalInput;
    private float _verticalInput;
    private float _horizontalBounds = 9f;
    private float _topBound = 5f;
    private float _lowerBound = -11.7f;
    private int _animationState;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _pistol = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(0).GetComponent<Pistol>();
        _shotGun = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(1).GetComponent<ShotGun>();
        _machinegun = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(2).GetComponent<Machinegun>();
        _taser = GameObject.Find("Player").transform.GetChild(2).gameObject.transform.
            GetChild(3).GetComponent<Taser>();

        switchWeapon = GameObject.Find("Player").transform.GetChild(2).GetComponent<SwitchWeapon>();

        _powerUps = GameObject.Find("Game Manager").GetComponent<Powerups>();
        particleHolder = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();
        _animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (!_gameManager.gameOver && !_gameManager.stopGame)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime * _verticalInput);
            transform.Translate(Vector3.right * _speed * Time.deltaTime * _horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space) && switchWeapon.selectedWeapon == 2)
            {
                if (!_pistol.isReloading && !_shotGun.isReloading && !_machinegun.isReloading && !_taser.isReloading)
                {
                    particleShoot.Play();

                    _animationState = 4; // не работает

                    switch (switchWeapon.selectedWeapon)
                    {
                        case 0:
                            _pistol.Fire();
                            playerAudio.PlayOneShot(soundPistol, 1);
                            break;
                        case 1:
                            _shotGun.Fire();
                            playerAudio.PlayOneShot(soundShotGun, 1);
                            break;
                        case 2:
                            _machinegun.Fire();
                            playerAudio.PlayOneShot(soundMachinegun, 1);
                            break;
                        case 3:
                            _taser.Fire();
                            playerAudio.PlayOneShot(soundTaser, 1);
                            break;
                    }
                }
            }
            else
            {
                _animationState = 0;
            }

            if (transform.position.x > _horizontalBounds)
            {
                transform.position = new Vector3(_horizontalBounds, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -_horizontalBounds)
            {
                transform.position = new Vector3(-_horizontalBounds, transform.position.y, transform.position.z);
            }

            if (transform.position.z > _topBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _topBound);
            }

            if (transform.position.z < _lowerBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _lowerBound);
            }
        }
        else
        {
            _animator.gameObject.GetComponent<Animator>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);

            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
        }

        if (currentHealth <= 50)
        {
            fill.color = new Color(0.6f, 0, 0, 0.6f);

            if (currentHealth == 0)
            {
                _gameManager.gameOver = true;
                _gameManager.stopGame = true;
                _gameManager.GameOverPopUp();
            }
        }
        else if (currentHealth > 50)
            fill.color = new Color(1f, 1f, 1f, 0.6509804f); // base color

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _animationState = 1;
        }
        else
        {
            _animationState = 0;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _animationState = 1;
        }
        else
        {
            _animationState = 0;
        }
        _animator.SetInteger("state", _animationState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerArea"))
        {
            SkinChanger();
            playerAudio.PlayOneShot(soundChangeSkin, 1.0f);
        }

        if (other.gameObject.CompareTag("PowerUpHealth"))
        {
            _powerUps.AddHealth(30);
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(soundGetPowerUps, 1.0f);
        }

        if (other.gameObject.CompareTag("PowerUpExplosion"))
        {
            _powerUps.Explosion();
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(soundGetPowerUps, 1.0f);
            particleHolder.PlayParticle(1, gameObject.transform.position);
        }

        if (other.gameObject.CompareTag("PowerUpTime"))
        {
            _powerUps.AddTime(25);
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(soundGetPowerUps, 1.0f);
        }
    }

    private void SkinChanger()
    {
        if (gameObject.transform.GetChild(0))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeHealth()
    {
        // потом это можно использовать как усиление на ХП
        currentHealth += 20;
        healthBar.SetHealth(currentHealth);
    }
}