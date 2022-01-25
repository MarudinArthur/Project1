using UnityEngine;

public class Powerups : MonoBehaviour
{
    private PlayerController _playerController;
    private GameManager _gameManager;
    private GameObject[] _enemies;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void AddHealth(int health)
    {
        _playerController.currentHealth += health;
        _playerController.healthBar.SetHealth(_playerController.currentHealth);
    }

    public void Explosion()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var x in _enemies)
        {
            Destroy(x);
            _gameManager.score++;
        }
    }

    public void AddTime(int seconds)
    {
        _gameManager.time += seconds;
    }
}