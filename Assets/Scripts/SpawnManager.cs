using UnityEngine;
using TMPro;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameManager _gameManager;
    public TextMeshProUGUI waveCounter;

    private int waveNumber = 0;
    private int maxWave = 9;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

     private void SpawnEnemies(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (!_gameManager.gameOver & !_gameManager.stopGame)
            {
                int randomEnemyIndex = Random.Range(0, 2);
                Instantiate(enemyPrefabs[randomEnemyIndex], GenerateSpawnRandomPosition(), enemyPrefabs[randomEnemyIndex].transform.rotation);
            }
        }
    }

    private void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 && !_gameManager.stopGame && !_gameManager.gameOver)
        {
            waveNumber++;
            SpawnEnemies(6);
            waveCounter.text = "wave " + waveNumber + " of " + maxWave;
        }
    }

    private Vector3 GenerateSpawnRandomPosition()
    {
        int rndSpawnPosX = Random.Range(-14, 14);
        int rndSpawnPosZ = Random.Range(15, 20);
        Vector3 SpawnPos = new Vector3(rndSpawnPosX, 0, rndSpawnPosZ);
        return SpawnPos;
    }
}
