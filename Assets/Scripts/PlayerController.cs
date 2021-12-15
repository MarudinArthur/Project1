using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    public GameObject projectilePrefab;
    private GameManager _gameManager;
    public Animator animator;

    private float _horizontalInput;
    private float _verticalInput;
    private float _horizontalBounds = 9f;
    private float _topBound = 5f;
    private float _lowerBound = -11.7f;
    private int _state;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
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

            animator.SetInteger("state", _state);
        }
        else
        {
            animator.gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Projectile") && !collision.gameObject.CompareTag("TriggerArea"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerArea"))
        {
            SkinChanger();
        }
    }

    private void SkinChanger()
    {
        if (gameObject.transform.GetChild(0))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}