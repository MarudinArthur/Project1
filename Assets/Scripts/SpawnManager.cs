using UnityEngine;
using TMPro;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpsPrefab;
    private GameManager _gameManager;
    public TextMeshProUGUI waveCounter;
    private int _enemyToSpawn = 3;
    private float powerupStartDelay = 5;
    private float powerupRepeatRate = 7;

    private int waveNumber = 0;
    private int maxWave = 9;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnPowerUps", powerupStartDelay, powerupRepeatRate);
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

    private void SpawnPowerUps()
    {
        int randoPowerUpsIndex = Random.Range(0, 2);
        Instantiate(powerUpsPrefab[randoPowerUpsIndex], GeneratePowerUpSpawnPos(), powerUpsPrefab[randoPowerUpsIndex].transform.rotation);
    }

    private void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        int spawnedPowerUp1 = GameObject.FindGameObjectsWithTag("PowerUpHealth").Length;
        int spawnedPowerUp2 = GameObject.FindGameObjectsWithTag("PowerUpExplosion").Length;
        int spawnedPowerUp3 = GameObject.FindGameObjectsWithTag("PowerUpTime").Length;

        int spawnedPowerUpTotal = spawnedPowerUp1 + spawnedPowerUp2 + spawnedPowerUp3;


        if (enemyCount == 0 && !_gameManager.stopGame && !_gameManager.gameOver)
        {
            SpawnEnemies(_enemyToSpawn);
            waveNumber++;
            _enemyToSpawn += 2;

            waveCounter.text = "wave " + waveNumber + " of " + maxWave;
        }
    }

    /*
    IEnumerator DestroyPowerUp()
    {
        yield return new WaitForSeconds(10);
        
    }
    */

    private Vector3 GenerateSpawnRandomPosition()
    {
        int rndSpawnPosX = Random.Range(-11, 11);
        int rndSpawnPosZ = Random.Range(15, 20);
        Vector3 SpawnPos = new Vector3(rndSpawnPosX, 0, rndSpawnPosZ);
        return SpawnPos;
    }

    private Vector3 GeneratePowerUpSpawnPos()
    {
        int rndSpawnPosX = Random.Range(-14, 14);
        int rndSpawnPosZ = Random.Range(-2, -9);
        Vector3 SpawnPos = new Vector3(rndSpawnPosX, transform.position.y, rndSpawnPosZ);
        return SpawnPos;
    }
}
