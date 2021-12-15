using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameObject _player;
    private GameManager _gameManager;
    public Animator animator;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 lookDirection = (transform.position - _player.transform.position).normalized;
        if (!_gameManager.stopGame)
        {
            transform.Translate(lookDirection * _speed * Time.deltaTime);
            animator.gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            animator.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}