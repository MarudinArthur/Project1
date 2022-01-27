using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManagerGame : MonoBehaviour
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

    public void SettingsInGame()
    {
        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(true);
        _gameManager.stopGame = true;
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

        Transform skin1 = GameObject.Find("Player").transform.GetChild(0);
        Transform skin2 = GameObject.Find("Player").transform.GetChild(1);

        if (skin1)
            skin1.GetComponent<Animator>().enabled = true;
        if (skin2)
            skin2.GetComponent<Animator>().enabled = true;
    }

    public void CloseSettingsPopUp()
    {
        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(false);
        _gameManager.stopGame = false;

        Transform skin1 = GameObject.Find("Player").transform.GetChild(0);
        Transform skin2 = GameObject.Find("Player").transform.GetChild(1);

        if (skin1)
            skin1.GetComponent<Animator>().enabled = true;
        if (skin2)
            skin2.GetComponent<Animator>().enabled = true;
    }

    public void ToggleChangedMusic()
    {
        var toggle = _gameManager.GetComponent<AudioSource>();
        toggle.mute = !toggle.mute;
    }

    public void ToggleChangedSound()
    {
        if (_gameManager.soundDisable == false)
            _gameManager.soundDisable = true;
		else
            _gameManager.soundDisable = false;
    }

    public void EnterPlayerName()
    {
        GameObject.Find("Canvas").transform.GetChild(17).gameObject.SetActive(false);
        //GameObject.Find("Game Manager").GetComponent<GameManager>().stopGame = false;
    }
}