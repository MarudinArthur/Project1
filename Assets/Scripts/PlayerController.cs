﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    public GameObject projectilePrefab;
    private GameManager _gameManager;
    public Animator animator;
    public TextMeshProUGUI skinChangerClues;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Image fill;

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
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);

            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Projectile") && !collision.gameObject.CompareTag("TriggerArea"))
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
        }
    }

    private void SkinChanger()
    {
        if (gameObject.transform.GetChild(0))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}