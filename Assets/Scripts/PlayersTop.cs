using UnityEngine;
using TMPro;

public class PlayersTop : MonoBehaviour
{
    public static PlayersTop Instance;
    public TextMeshProUGUI totalScore;
    private GameManager _gameManager;

    private void Awake()
    {/*
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }*/

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            totalScore.text = "1. " + _gameManager.nameInput + " : " + _gameManager.score;
        }
    }
}