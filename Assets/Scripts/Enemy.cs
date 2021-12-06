using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (transform.position - _player.transform.position).normalized;
        transform.Translate(lookDirection * _speed * Time.deltaTime);
    }
}