using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [HideInInspector] public int currentHealth;

    public GameObject projectilePrefab;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Image fill;
    public AudioClip soundShoot;
    public AudioClip soundChangeSkin;
    public AudioClip soundGetPowerUps;
    private ParticleHolder particle;
    public ParticleSystem shootParticle;

    private GameManager _gameManager;
    private Powerups _powerUps;
    public Animator _animator;
    private AudioSource playerAudio;
    private float _horizontalInput;
    private float _verticalInput;
    private float _horizontalBounds = 9f;
    private float _topBound = 5f;
    private float _lowerBound = -11.7f;
    private int _state;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _powerUps = GameObject.Find("Game Manager").GetComponent<Powerups>();
        particle = GameObject.Find("ParticleHolder").GetComponent<ParticleHolder>();
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                _state = 4;
                playerAudio.PlayOneShot(soundShoot, 1.0f);
                shootParticle.Play();
            }
            else
            {
                _state = 0;
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

            _animator.SetInteger("state", _state);
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            // потом это можно использовать как усиление на ХП
            TakeHealth();
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Projectile") && !collision.gameObject.CompareTag("TriggerArea"))
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
            playerAudio.PlayOneShot(soundChangeSkin, 1.0f);
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
            particle.PlayParticle(1, gameObject.transform.position);
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