using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private float _speed = 2.5f;

    void Update()
    {
        transform.Rotate(gameObject.transform.rotation.x, 2, gameObject.transform.rotation.z * _speed * Time.deltaTime);
    }
}