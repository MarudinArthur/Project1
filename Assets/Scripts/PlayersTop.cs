using UnityEngine;
using TMPro;

public class PlayersTop : MonoBehaviour
{
    public TextMeshProUGUI totalScore;
    private GameManager gameManager;

    private void Start()
    {
        

        if (GameManager.Instance != null)
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            totalScore.text = "1. " + gameManager.nameInput + " : " + gameManager.score;
        }
    }
}