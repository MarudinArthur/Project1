using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_gameManager.stopGame)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
