using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public int currentHealth;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Image fill;
    [SerializeField] private AudioClip soundPistol;
    [SerializeField] private AudioClip soundShotGun;
    [SerializeField] private AudioClip soundMachinegun;
    [SerializeField] private AudioClip soundTaser;
    [SerializeField] private AudioClip soundChangeSkin;
    [SerializeField] private AudioClip soundGetPowerUps;
    [SerializeField] private ParticleSystem particleShoot;
    
    public HealthBar healthBar;
    
    private const float Speed = 10f;
    private Animator _animatorSkin1;
    private Animator _animatorSkin2;
    private ParticleHolder _particleHolder;

    private GameManager _gameManager;
    private SwitchWeapon _switchWeapon;
    private Powerups _powerUps;
    private AudioSource _playerAudio;

    private Pistol _pistol;
    private ShotGun _shotGun;
    private ShotGun2 _shotGun2;
    private Machinegun2 _machinegun2;
    private Machinegun _machinegun;
    private Taser _taser;

    private Transform _skin1;
    private Transform _skin2;

    private float _horizontalInput;
    private float _verticalInput;
    private const float HorizontalBounds = 9f;
    private const float TopBound = 5f;
    private const float LowerBound = -11.7f;
    private int _animationState;
    private Transform _startGamePopUp;
    private GameObject _canvas;
    private static readonly int State = Animator.StringToHash("state");

    private void Start()
    {
        var weaponHolder = GameObject.Find("Player").transform.GetChild(2);
        _canvas = GameObject.Find("Canvas");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _particleHolder = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();
/*
        var scripts = gameObject.GetComponents<MonoBehaviour>();

        for (var i  = 0; i  < weaponHolder.childCount; i ++)
        {
            for (var k = 0; k < scripts.Length; k++)
            {
                var data = scripts[k];
                weaponHolder.GetChild(k).GetComponent<MonoBehaviour>();
            }
        }
*/
        _pistol = weaponHolder.GetChild(0).GetComponent<Pistol>();
        _shotGun = weaponHolder.GetChild(1).GetComponent<ShotGun>();
        _shotGun2 = weaponHolder.GetChild(2).GetComponent<ShotGun2>();
        _machinegun = weaponHolder.GetChild(3).GetComponent<Machinegun>();
        _machinegun2 = weaponHolder.GetChild(4).GetComponent<Machinegun2>();
        _taser = weaponHolder.GetChild(5).GetComponent<Taser>();

        _switchWeapon = weaponHolder.GetComponent<SwitchWeapon>();
        _powerUps = _gameManager.GetComponent<Powerups>();

        _skin1 = gameObject.transform.GetChild(0);
        _skin2 = gameObject.transform.GetChild(1);
        
        _animatorSkin1 = transform.GetChild(0).GetComponent<Animator>();
        _animatorSkin2 = transform.GetChild(1).GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        _canvas.transform.GetChild(17).gameObject.SetActive(true);
    }

    private void Update()
    { 
        _horizontalInput = Input.GetAxis("Horizontal"); 
        _verticalInput = Input.GetAxis("Vertical"); 
        if (!_gameManager.gameOver && !_gameManager.stopGame) 
        { 
            transform.Translate(Vector3.forward * (Speed * Time.deltaTime * _verticalInput)); 
            transform.Translate(Vector3.right * (Speed * Time.deltaTime * _horizontalInput));
                
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space) && _switchWeapon.selectedWeapon == 3) 
            { 
                if (!_pistol.isReloading && !_shotGun.isReloading && !_machinegun.isReloading && !_taser.isReloading && !_shotGun2.isReloading && !_machinegun2.isReloading) 
                { 
                    particleShoot.Play();
                    _animationState = 4;

                    switch (_switchWeapon.selectedWeapon)
                    {
                        case 0:
                            _pistol.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundPistol, 1);
                            break;
                        case 1:
                            _shotGun.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundShotGun, 1);
                            break;
                        case 2:
                            _shotGun2.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundShotGun, 1);
                            break;
                        case 3:
                            _machinegun.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundMachinegun, 1);
                            break;
                        case 4:
                            _machinegun2.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundMachinegun, 1);
                            break;
                        case 5:
                            _taser.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundTaser, 1);
                            break;
                    }
                }
            }
            else
            {
                _animationState = 0;
            }

            if (transform.position.x > HorizontalBounds)
                transform.position = new Vector3(HorizontalBounds, transform.position.y, transform.position.z);

            if (transform.position.x < -HorizontalBounds)
                transform.position = new Vector3(-HorizontalBounds, transform.position.y, transform.position.z);

            if (transform.position.z > TopBound)
                transform.position = new Vector3(transform.position.x, transform.position.y, TopBound);

            if (transform.position.z < LowerBound)
                transform.position = new Vector3(transform.position.x, transform.position.y, LowerBound);
        }
        else
        {
            if (_animatorSkin1)
                _animatorSkin1.GetComponent<Animator>().enabled = false;
            if (_animatorSkin2)
                _animatorSkin2.GetComponent<Animator>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // skin change
            _skin1.gameObject.SetActive(true);
            _skin2.gameObject.SetActive(false);

            // disable clue
            _canvas.transform.GetChild(9).gameObject.SetActive(false);
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
            _animationState = 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            _animationState = 1;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _animationState = 2;
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _animationState = 3;

        _animatorSkin1.SetInteger(State, _animationState);
        _animatorSkin2.SetInteger(State, _animationState);
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
            if (!_gameManager.soundDisable)
                _playerAudio.PlayOneShot(soundChangeSkin, 1.0f);
        }

        if (other.gameObject.CompareTag("PowerUpHealth"))
        {
            _powerUps.AddHealth(30);
            Destroy(other.gameObject);
            if (!_gameManager.soundDisable)
                _playerAudio.PlayOneShot(soundGetPowerUps, 1.0f);
        }

        if (other.gameObject.CompareTag("PowerUpExplosion"))
        {
            _powerUps.Explosion();
            Destroy(other.gameObject);
            _particleHolder.PlayParticle(1, gameObject.transform.position);
            if (!_gameManager.soundDisable)
                _playerAudio.PlayOneShot(soundGetPowerUps, 1.0f);
        }

        if (other.gameObject.CompareTag("PowerUpTime"))
        {
            _powerUps.AddTime(25);
            Destroy(other.gameObject);
            if (!_gameManager.soundDisable)
                _playerAudio.PlayOneShot(soundGetPowerUps, 1.0f);
        }
    }

    private void SkinChanger()
    {
        if (_skin1)
        {
            _skin1.gameObject.SetActive(false);
            _skin2.gameObject.SetActive(true);
            // show clue
            _canvas.transform.GetChild(9).gameObject.SetActive(true);
        }
        else
        {
            _canvas.transform.GetChild(9).gameObject.SetActive(false);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}