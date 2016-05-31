using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string StartLevel;

    public Canvas HighscoreCanvas;
    public Canvas CallsignCanvas;
    public Canvas MainMenuCanvas;
    public Canvas AboutCanvas;

    public InputField CallsignInput;

    public List<Text> HighScores;

    public void Start()
    {
        CallsignCanvas.enabled = false;
        HighscoreCanvas.enabled = false;
        AboutCanvas.enabled = false;

        new HighScoreController().CheckIfHighscoresExist();
    }

    public void EnterCallsign()
    {
        MainMenuCanvas.enabled = false;
        CallsignCanvas.enabled = true;
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(CallsignInput.text))
            return;

        PlayerPrefs.SetString("PlayerName", CallsignInput.text);

        float fadeTime = GameObject.FindGameObjectWithTag(Constants.Tags.LEVEL_EVENTS).GetComponent<Fading>().BeginFade(1);
        new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(StartLevel);
    }

    public void OpenHighscore()
    {
        MainMenuCanvas.enabled = false;
        HighscoreCanvas.enabled = true;
        GetHighscores();
    }

    public void CloseHighscore()
    {
        HighscoreCanvas.enabled = false;
        MainMenuCanvas.enabled = true;
    }

    public void OpenAbout()
    {
        MainMenuCanvas.enabled = false;
        AboutCanvas.enabled = true;
    }

    public void CloseAbout()
    {
        AboutCanvas.enabled = false;
        MainMenuCanvas.enabled = true;
    }

    public void QuitGame()
    {
        Debug.Log("Finito!");
        Application.Quit();
    }

    void GetHighscores()
    {
        for (int i = 0; i < HighScores.Count; i++)
        {
            HighScores[i].text = PlayerPrefs.GetString("HSK" + i) + " " + PlayerPrefs.GetInt("HSV" + i);
        }
    }
}
