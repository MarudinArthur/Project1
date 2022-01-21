using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
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
        GameObject.Find("Game Manager").GetComponent<GameManager>().stopGame = true;
    }

    public void SettingsInMenu()
	{
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
	}
    public void CloseSettingsInMenu()
	{
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
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
        GameObject.Find("Game Manager").GetComponent<GameManager>().stopGame = true;
    }

    public void CloseHomePopUp()
    {
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(false);
        GameObject.Find("Game Manager").GetComponent<GameManager>().stopGame = false;

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
        GameObject.Find("Game Manager").GetComponent<GameManager>().stopGame = false;

        Transform skin1 = GameObject.Find("Player").transform.GetChild(0);
        Transform skin2 = GameObject.Find("Player").transform.GetChild(1);

        if (skin1)
            skin1.GetComponent<Animator>().enabled = true;
        if (skin2)
            skin2.GetComponent<Animator>().enabled = true;
    }

    public void ToggleChangedMusic()
    {
        var toggle = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        toggle.mute = !toggle.mute;
    }

    public void ToggleChangedSound()
	{
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (gameManager.soundDisable == false)
            gameManager.soundDisable = true;
		else
            gameManager.soundDisable = false;
    }
}