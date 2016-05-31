using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public float SliderMaxValue = 60.0f;
    public float SliderStartValue = 0.0f;
    public Slider MapLengthSlider;
    public string NextLevel;
    public Text TopHighscore;

    void Start()
    {
        TopHighscore.text = PlayerPrefs.GetInt("HSV0").ToString("D6");
    }

    void FixedUpdate()
    {
        SliderStartValue += Time.deltaTime;
        MapLengthSlider.value = SliderStartValue;

        if (SliderStartValue > SliderMaxValue)
        {
            new HighScoreController().InsertNewHighScore(GameObject.FindGameObjectWithTag(Constants.Tags.PLAYER).GetComponent<PlayerData>().HighScore);
            SceneManager.LoadScene(NextLevel);
        }
    }
}
