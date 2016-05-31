using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    bool paused = false;
    Canvas canvas;

    void Start()
    {
        //Cursor.visible = false;
        canvas = this.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;

            if (paused)
                StopGame();
            else
                ResumeGame();
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
        //Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
        //Cursor.visible = false;
        paused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constants.Levels.MENU);
    }
}
