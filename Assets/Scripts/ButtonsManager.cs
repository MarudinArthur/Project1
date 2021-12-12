using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    public void HomeButton()
    {
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(true);
        _gameManager.stopGame = true;
    }

    public void CloseHomePopUp()
    {
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(false);
    }
}