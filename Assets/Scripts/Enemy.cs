using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Fields

    [HideInInspector] public int enemyMaxHealth = 60;
    [HideInInspector] public int enemyCurrentHealth;
    [SerializeField] private float speed = 5f;
    [SerializeField] private AudioClip soundEnemyDeath;
    [SerializeField] private AudioClip soundEnemyHit;
    [SerializeField] private Image fill;
    [SerializeField] private ParticleSystem particleHit;
    [SerializeField] private HealthBar enemyHealthBar;
    
    private int _counter = 3;
    private int _animationState;
    private GameObject _player;
    private GameManager _gameManager;
    private Animator _animator;
    private Pistol _pistol;
    private ShotGun _shotGun;
    private Machinegun _machinegun;
    private Taser _taser;
    private AudioSource _audioSource;
    private static readonly int State = Animator.StringToHash("state");

    #endregion

    private void Start()
    {
        _player = GameObject.Find("Player");
        var weaponHolder = _player.transform.GetChild(2);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();

        _pistol = weaponHolder.transform.GetChild(0).GetComponent<Pistol>();
        _shotGun = weaponHolder.transform.GetChild(1).GetComponent<ShotGun>();
        _machinegun = weaponHolder.transform.GetChild(3).GetComponent<Machinegun>();
        _taser = weaponHolder.transform.GetChild(5).GetComponent<Taser>();

        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxHealth(enemyMaxHealth);
    }

    private void Update()
    {
        var lookDirection = (transform.position - _player.transform.position).normalized;

        if (!_gameManager.stopGame && !_gameManager.gameOver)
        {
            transform.Translate(lookDirection * (speed * Time.deltaTime));
            _animator.gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            _animator.gameObject.GetComponent<Animator>().enabled = false;
        }

        if (enemyCurrentHealth <= 0 && gameObject != null)
        {
            Destroy(gameObject, 1.5f);
            _animationState = 2;

            // отключаю хелсбар
            transform.GetChild(2).gameObject.SetActive(false);
        }
        _animator.SetInteger(State, _animationState);
    }

    private void TakeDamageEnemy(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
        if (enemyCurrentHealth == 0)
		{
            _gameManager.score++;
            
            if (!_gameManager.soundDisable)
                _audioSource.PlayOneShot(soundEnemyDeath, 1);
        }
    }

    public void TakeTaserDamageEnemy()
    { 
        enemyCurrentHealth -= _taser.damage;
        Debug.Log(enemyCurrentHealth);
        enemyHealthBar.SetHealth(enemyCurrentHealth);

        if (--_counter == 0) 
            CancelInvoke(nameof(TakeTaserDamageEnemy));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // дамаг соответствует выбранной пушки (пули):
        if (collision.gameObject.CompareTag("PistolProjectile"))
        {
            TakeDamageEnemy(_pistol.damage);
            Destroy(collision.gameObject);
            particleHit.Play();
            if (!_gameManager.soundDisable)
                _audioSource.PlayOneShot(soundEnemyHit, 1);
        }
        if (collision.gameObject.CompareTag("ShotgunProjectile"))
        {
            TakeDamageEnemy(_shotGun.damage);
            Destroy(collision.gameObject);
            particleHit.Play();
            if (!_gameManager.soundDisable)
                _audioSource.PlayOneShot(soundEnemyHit, 1);

        }
        if (collision.gameObject.CompareTag("MachinegunProjectile"))
        {
            TakeDamageEnemy(_machinegun.damage);
            Destroy(collision.gameObject);
            particleHit.Play();
            if (!_gameManager.soundDisable)
                _audioSource.PlayOneShot(soundEnemyHit, 1);
        }

        if (collision.gameObject.CompareTag("TaserProjectile"))
        {
            InvokeRepeating(nameof(TakeTaserDamageEnemy), 0, 1);
            Destroy(collision.gameObject);
            particleHit.Play();
            
            if (!_gameManager.soundDisable)
                _audioSource.PlayOneShot(soundEnemyHit, 1);
        }
    }
}