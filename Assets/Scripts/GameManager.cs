using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float _time = 5f;

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (_time > 0.00f)
        {
            _time -= Time.deltaTime;
            float totalTime = ((int)(_time * 100)) / 100f;
            timer.text = "" + totalTime;
        }
    }
}