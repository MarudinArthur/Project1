using UnityEditor;
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
        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(true);
        _gameManager.stopGame = true;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    public void HomeButton()
    {
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(true);
        _gameManager.stopGame = true;
    }

    public void CloseHomePopUp()
    {
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(false);
        _gameManager.stopGame = false;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
    }

    public void CloseSettingsPopUp()
    {
        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(false);
        _gameManager.stopGame = false;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
    }

    public void ToggleChanged()
    {
        var toggle = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        toggle.mute = !toggle.mute;
    }
}