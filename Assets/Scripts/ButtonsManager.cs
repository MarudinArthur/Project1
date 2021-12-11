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

    public void Settings()
    {
        //some code
    }

    public void Exit()
    {
        //some code
    }
}