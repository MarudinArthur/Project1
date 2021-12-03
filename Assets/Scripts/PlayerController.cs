using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 10;
    private float _horizontalInput;
    private float _verticalInput;
    public GameObject projectilePrefab;

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
    }
}
