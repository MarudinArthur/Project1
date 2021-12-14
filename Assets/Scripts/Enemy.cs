using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameObject _player;
    private GameManager _gameManager;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        Vector3 lookDirection = (transform.position - _player.transform.position).normalized;
        if (!_gameManager.stopGame)
        {
            transform.Translate(lookDirection * _speed * Time.deltaTime);
        }
    }
}