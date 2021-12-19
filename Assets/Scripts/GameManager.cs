﻿using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float score = 0f;
    [HideInInspector] public bool gameOver = false;
    [HideInInspector] public bool stopGame = false;
    public static GameManager Instance;
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI scoreCounter;
    private float _time = 15f;

    /*
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
      
        //GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }*/

    private void Update()
    {
        Timer();
        Score();
    }

    public void Timer()
    {
        if(stopGame != true)
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
    }

    public void Score()
    {
        // show current score
        scoreCounter.text = "score: " + score;
    }

    public void GameOverPopUp()
    {
        // show pop-up
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        // disable skin change clues (if enable)
        GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
    }
}