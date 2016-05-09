using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    bool paused = false;

    void Start()
    {
        Cursor.visible = false;
        gameObject.transform.localPosition = new Vector3(100.0f, 100.0f, 1001.0f);
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
        gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.transform.localPosition = new Vector3(100.0f, 100.0f, 1001.0f);
        Cursor.visible = false;
        paused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constants.Levels.MENU);
    }
}
