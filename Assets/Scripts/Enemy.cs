using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameObject _player;
    private GameManager _gameManager;
    public Animator animator;
    public AudioClip soundEnemyDeath;
    private AudioSource enemyAudio;
    public int enemyMaxHealth = 60;
    public int enemyCurrentHealth;
    public HealthBar enemyHealthBar;
    public Image fill;
    private ParticleHolder particle;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        particle = GameObject.Find("ParticleHolder").GetComponent<ParticleHolder>();
        enemyAudio = GetComponent<AudioSource>();
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
                enemyAudio.PlayOneShot(soundEnemyDeath, 1.0f);
                particle.PlayParticle(0, gameObject.transform.position);
                Destroy(gameObject);
                _gameManager.score++;
            }
        }
    }

    public void TakeDamageEnemy(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamageEnemy(20);
        }
    }
}