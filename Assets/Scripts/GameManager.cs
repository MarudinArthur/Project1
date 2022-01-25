using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool gameOver = false;
    [HideInInspector] public bool stopGame = false;
    [HideInInspector] public bool soundDisable = false;

    public float score = 0f;
    public float time = 60f;
    public static GameManager Instance;
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI scoreCounter;
    public TextMeshProUGUI playerName;
    public TMP_InputField nameInput;

    private void Awake()
    {
        /*if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
      
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
        */
        //nameInput = MainManager.Instance.playerName.text;
    }

    private void Update()
    {
        Timer();
        Score();

        playerName.text = "Player : " + nameInput.text;
    }

    private void Timer()
    {
        if (stopGame != true)
        {
            if (time > (int)0)
            {
                time -= Time.deltaTime;
                var totalTime = ((int)(time * 100)) / 100f;
                timerCounter.text = "" + totalTime;

                if (time < 5)
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

    private void Score()
    {
        // show current score
        scoreCounter.text = "score: " + score;

        playerName.text = "Player : " + nameInput;
    }

    public static void GameOverPopUp()
    {
        // show pop-up
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        // disable skin change clues (if enable)
        GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
    }
}