using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float score = 0f;
    [HideInInspector] public bool gameOver = false;
    public static GameManager Instance;
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI scoreCounter;
    private float _time = 10f;

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
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        //some code
    }

    public void Exit()
    {
        //some code
    }
}