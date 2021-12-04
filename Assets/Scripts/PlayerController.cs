using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    public GameObject projectilePrefab;

    private float _horizontalInput;
    private float _verticalInput;
    private float _horizontalBounds = 9f;
    private float _topBound = 5f;
    private float _lowerBound = -11.7f;


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * _speed * Time.deltaTime * _verticalInput);
        transform.Translate(Vector3.right * _speed * Time.deltaTime * _horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
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
}
