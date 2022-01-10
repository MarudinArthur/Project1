using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameObject _player;
    private GameManager _gameManager;
    public Animator animator;

    public int enemyMaxHealth = 60;
    public int enemyCurrentHealth;
    private int _state;
    public HealthBar enemyHealthBar;
    public Image fill;
    private ParticleHolder particle;
    private AudioSource audioSource;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
                Destroy(gameObject, 3.5f);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamageEnemy(20);
        }
    }
}