using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float score = 0f;
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI scoreCounter;
    private float _time = 60f;

    private void Update()
    {
        Timer();
        Score();
    }

    public void Timer()
    {
        if (_time > 0.00f)
        {
            _time -= Time.deltaTime;
            float totalTime = ((int)(_time * 100)) / 100f;
            timerCounter.text = "" + totalTime;
        }
    }

    public void Score()
    {
        scoreCounter.text = "score: " + score;
    }
}