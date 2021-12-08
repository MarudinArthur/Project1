using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float score = 0f;
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI scoreCounter;
    private float _time = 10f;
    public bool gameOver = false;

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
        }
    }

    public void Score()
    {
        scoreCounter.text = "score: " + score;
    }
}