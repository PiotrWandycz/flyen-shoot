using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour 
{
    public string StartLevel;

    public void StartGame()
    {
        SceneManager.LoadScene(StartLevel);
    }

    public void OpenOptions()
    {
        Debug.Log("Options clicked.");
    }

    public void OpenHighscore()
    {
        Debug.Log("Highscore clicked.");
    }

    public void QuitGame()
    {
        Debug.Log("Finito!");
        Application.Quit();
    }
}
