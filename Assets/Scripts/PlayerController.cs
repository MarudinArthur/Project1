using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Fields

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
    
    [Header("Weapons")]
    public Pistol pistol;
    public ShotGun shotGun;
    public ShotGun2 shotGun2;
    public Machinegun2 machinegun2;
    public Machinegun machinegun;
    public Taser taser;

    [Header("Skins")]
    public Transform skin1;
    public Transform skin2;
    
    [Header("SkinsAnimator")]
    public Animator animatorSkin1;
    public Animator animatorSkin2;

    private const float Speed = 10f;
    private ParticleHolder _particleHolder;

    private GameManager _gameManager;
    private SwitchWeapon _switchWeapon;
    private Powerups _powerUps;
    private AudioSource _playerAudio;
    
    private float _horizontalInput;
    private float _verticalInput;
    private const float HorizontalBounds = 9f;
    private const float TopBound = 5f;
    private const float LowerBound = -11.7f;
    private int _animationState;
    private Transform _startGamePopUp;
    private GameObject _canvas;
    private static readonly int State = Animator.StringToHash("state");

    private Weapon.WeaponType _weaponType;

    #endregion

    private void Start()
    {
        var weaponHolder = GameObject.Find("Player").transform.GetChild(2);
        _canvas = GameObject.Find("Canvas");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _particleHolder = GameObject.Find("Particle Holder").GetComponent<ParticleHolder>();

        _switchWeapon = weaponHolder.GetComponent<SwitchWeapon>();
        _powerUps = _gameManager.GetComponent<Powerups>();
        
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
                if (!pistol.isReloading && !shotGun.isReloading && !machinegun.isReloading && !taser.isReloading && !shotGun2.isReloading && !machinegun2.isReloading) 
                { 
                    particleShoot.Play();
                    _animationState = 4;

                    switch (_switchWeapon.selectedWeapon)
                    {
                        case 0:
                            pistol.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundPistol, 1);
                            break;
                        case 1:
                            shotGun.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundShotGun, 1);
                            break;
                        case 2:
                            shotGun2.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundShotGun, 1);
                            break;
                        case 3:
                            machinegun.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundMachinegun, 1);
                            break;
                        case 4:
                            machinegun2.Fire();
                            if (!_gameManager.soundDisable)
                                _playerAudio.PlayOneShot(soundMachinegun, 1);
                            break;
                        case 5:
                            taser.Fire();
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
            if (animatorSkin1)
                animatorSkin1.GetComponent<Animator>().enabled = false;
            if (animatorSkin2)
                animatorSkin2.GetComponent<Animator>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // skin change
            skin1.gameObject.SetActive(true);
            skin2.gameObject.SetActive(false);

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

        animatorSkin1.SetInteger(State, _animationState);
        animatorSkin2.SetInteger(State, _animationState);
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
        if (skin1)
        {
            skin1.gameObject.SetActive(false);
            skin2.gameObject.SetActive(true);
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