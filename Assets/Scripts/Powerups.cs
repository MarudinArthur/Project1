﻿using UnityEngine;

public class Powerups : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;
    private GameObject[] enemies;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void AddHealth(int damage)
    {
        playerController.currentHealth += damage;
        playerController.healthBar.SetHealth(playerController.currentHealth);
    }

    public void Explosion()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void AddTime(int seconds)
    {
        gameManager.time += seconds;
    }

    public void Shield()
    {
        Debug.Log("SHIELD");
    }
}