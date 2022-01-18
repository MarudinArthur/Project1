using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameObject _player;
    private GameManager _gameManager;
    public Animator animator;

    private Pistol _pistol;
    private ShotGun _shotGun;
    private Machinegun _machinegun;
    private Taser _taser;

    public int enemyMaxHealth = 60;
    public int enemyCurrentHealth;
    private int _state;
    public HealthBar enemyHealthBar;
    public Image fill;
    private ParticleHolder particle;
    private AudioSource audioSource;

    private int counter = 3;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _pistol = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(0).GetComponent<Pistol>();
        _shotGun = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
           GetChild(1).GetComponent<ShotGun>();
        _machinegun = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(2).GetComponent<Machinegun>();
        _taser = GameObject.Find("Player").transform.GetChild(3).gameObject.transform.
            GetChild(3).GetComponent<Taser>();

        particle = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxHealth(enemyMaxHealth);
    }

    void Update()
    {
        Vector3 lookDirection = (transform.position - _player.transform.position).normalized;

        if (!_gameManager.stopGame && !_gameManager.gameOver)
        {
            transform.Translate(lookDirection * _speed * Time.deltaTime);
            animator.gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            animator.gameObject.GetComponent<Animator>().enabled = false;
        }

        if (enemyCurrentHealth == 0)
        {
            if (gameObject != null)
            {
                audioSource.Play();
                particle.PlayParticle(0, gameObject.transform.position);
                Destroy(gameObject, 1.5f);

                // отключаю хелсбар
                transform.GetChild(2).gameObject.SetActive(false);

                _state = 2;
                _gameManager.score++;
            }
            animator.SetInteger("state", _state);
        }
    }
    public void TakeDamageEnemy(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
    }

    public void TakeTaserDamageEnemy()
    { 

        enemyCurrentHealth -= _taser.WeaponDamage;
        Debug.Log(enemyCurrentHealth);
        enemyHealthBar.SetHealth(enemyCurrentHealth);

        if (--counter == 0) CancelInvoke("TakeTaserDamageEnemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // дамаг соответствует выбранной пушки (пули):
        if (collision.gameObject.CompareTag("PistolProjectile"))
        {
            TakeDamageEnemy(_pistol.WeaponDamage);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("ShotgunProjectile"))
        {
            TakeDamageEnemy(_shotGun.WeaponDamage);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("MachinegunProjectile"))
        {
            TakeDamageEnemy(_machinegun.WeaponDamage);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("TaserProjectile"))
        {
            InvokeRepeating("TakeTaserDamageEnemy", 0, 1);

            Destroy(collision.gameObject);
        }
    }
}