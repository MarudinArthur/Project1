using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManagerMenu : MonoBehaviour
{
    private Transform _settingPopUp;
    
    private void Start()
    {
        _settingPopUp = GameObject.Find("Canvas").transform.GetChild(1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsInMenu()
	{
        _settingPopUp.gameObject.SetActive(true);
	}
    public void CloseSettingsInMenu()
	{
        _settingPopUp.gameObject.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}