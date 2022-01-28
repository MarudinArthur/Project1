using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpsPrefab;
    public TextMeshProUGUI waveCounter;
    
    private const float PowerupStartDelay = 8;
    private const float PowerupRepeatRate = 7;
    private int _enemyToSpawn = 3;
    private int _spawnedPowerUp1;
    private int _spawnedPowerUp2;
    private int _spawnedPowerUp3;
    private int _waveNumber;
    private const int MaxWave = 9;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating(nameof(SpawnPowerUps), PowerupStartDelay, PowerupRepeatRate);
    }

     private void SpawnEnemies(int enemiesToSpawn)
    {
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            if (!_gameManager.gameOver & !_gameManager.stopGame)
            {
                var randomEnemyIndex = Random.Range(0, 2);
                Instantiate(enemyPrefabs[randomEnemyIndex], GenerateSpawnRandomPosition(), 
                    enemyPrefabs[randomEnemyIndex].transform.rotation);
            }
        }
    }

    private void SpawnPowerUps()
    {
        if (_spawnedPowerUp1 == 0 && _spawnedPowerUp2 == 0 && _spawnedPowerUp3 == 0)
        {
            var randoPowerUpsIndex = Random.Range(0, 2);
            Instantiate(powerUpsPrefab[randoPowerUpsIndex], GeneratePowerUpSpawnPos(), 
                powerUpsPrefab[randoPowerUpsIndex].transform.rotation);
        }
    }

    private void Update()
    {
        // этот кусок явно очень проблемный, буду думать как сделать лучше
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        _spawnedPowerUp1 = GameObject.FindGameObjectsWithTag("PowerUpHealth").Length; 
        _spawnedPowerUp2 = GameObject.FindGameObjectsWithTag("PowerUpExplosion").Length; 
        _spawnedPowerUp3 = GameObject.FindGameObjectsWithTag("PowerUpTime").Length;

        if (enemyCount == 0 && !_gameManager.stopGame && !_gameManager.gameOver)
        {
            SpawnEnemies(_enemyToSpawn);
            _waveNumber++;
            _enemyToSpawn += 2;

            waveCounter.text = "wave " + _waveNumber + " of " + MaxWave;
        }
    }

    private static Vector3 GenerateSpawnRandomPosition()
    {
        var rndSpawnPosX = Random.Range(-11, 11);
        var rndSpawnPosZ = Random.Range(15, 20);
        var spawnPos = new Vector3(rndSpawnPosX, 0, rndSpawnPosZ);
        return spawnPos;
    }

    private Vector3 GeneratePowerUpSpawnPos()
    {
        var rndSpawnPosX = Random.Range(-8, 8);
        var rndSpawnPosZ = Random.Range(-2, -9);
        var spawnPos = new Vector3(rndSpawnPosX, transform.position.y, rndSpawnPosZ);
        return spawnPos;
    }
}