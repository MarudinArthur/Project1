using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float score = 0f;
    [HideInInspector] public bool gameOver = false;
    private Canvas canvas;
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI scoreCounter;
    private float _time = 10f;

    private void Start()
    {
        //canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        Timer();
        Score();
    }

    public void Timer()
    {
        if (_time > (int)0)
        {
            _time -= Time.deltaTime;
            float totalTime = ((int)(_time * 100)) / 100f;
            timerCounter.text = "" + totalTime;

            if (_time < 5)
            {
                timerCounter.color = Color.red;
            }
        }
        else
        {
            gameOver = true;
            GameOverPopUp();
        }
    }

    public void Score()
    {
        scoreCounter.text = "score: " + score;
    }

    private void GameOverPopUp()
    {
        //gameObject.transform.GetChild(0).gameObject.SetActive(true)
        //canvas.transform.GetChild(4).gameObject.SetActive(true);
        //_gameOverPopUp.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
    }
}