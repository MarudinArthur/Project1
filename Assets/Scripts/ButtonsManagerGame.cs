using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManagerGame : MonoBehaviour
{
    private GameManager _gameManager;
    private Transform _homePopUp;
    private Transform _settingsPopUp;
    private Transform _skin1;
    private Transform _skin2;
    private Animator _animator1;
    private Animator _animator2;
    private GameObject _player;
    private GameObject _canvas;

    private void Start()
    { 
        _player = GameObject.Find("Player");
        _canvas = GameObject.Find("Canvas");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        _homePopUp = _canvas.transform.GetChild(8);
        _settingsPopUp = _canvas.transform.GetChild(10);
        
        _skin1 = _player.transform.GetChild(0);
        _skin2 = _player.transform.GetChild(1);
        _animator1 = _skin1.GetComponent<Animator>();
        _animator2 = _skin2.GetComponent<Animator>();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsButtonInGame()
    {
        _settingsPopUp.gameObject.SetActive(true);
        _gameManager.stopGame = true;
    }

    public void HomeButton()
    {
        _homePopUp.gameObject.SetActive(true);
        _gameManager.stopGame = true;
    }

    public void CloseHomePopUp()
    {
        _homePopUp.gameObject.SetActive(false);
        _gameManager.stopGame = false;

        if (_skin1)
            _animator1.enabled = true;
        if (_skin2)
            _animator2.enabled = true;
    }

    public void CloseSettingsPopUp()
    {
        _settingsPopUp.gameObject.SetActive(false);
        _gameManager.stopGame = false;

        if (_skin1)
            _animator1.enabled = true;
        if (_skin2)
            _animator2.enabled = true;
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
        _canvas.transform.GetChild(17).gameObject.SetActive(false);
    }
}