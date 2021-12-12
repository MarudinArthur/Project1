using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameManager _gameManager;
    private float _spawnDelay = 2f;
    private float _repeatRate = 2f;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnEnemies", _spawnDelay, _repeatRate);
    }

     private void SpawnEnemies()
    {
        if (!_gameManager.gameOver & !_gameManager.stopGame)
        {
            int randomEnemyIndex = Random.Range(0, 2);
            Instantiate(enemyPrefabs[randomEnemyIndex], GenerateSpawnRandomPosition(), enemyPrefabs[randomEnemyIndex].transform.rotation);
        }    
    }
    
    private Vector3 GenerateSpawnRandomPosition()
    {
        int rndSpawnPosX = Random.Range(-14, 14);
        int spawnPosZ = 15;
        Vector3 SpawnPos = new Vector3(rndSpawnPosX, 0, spawnPosZ);
        return SpawnPos;
    }
}
