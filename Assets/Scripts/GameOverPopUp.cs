using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopUp : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }
}
