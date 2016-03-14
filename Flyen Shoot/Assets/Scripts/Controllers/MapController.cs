using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapController : MonoBehaviour 
{
    public float SliderMaxValue = 60.0f;
    public float SliderStartValue = 0.0f;
    public Slider MapLengthSlider;
    public string NextLevel;

	void FixedUpdate () 
    {
        SliderStartValue += Time.deltaTime;
        MapLengthSlider.value = SliderStartValue;

        if (SliderStartValue > SliderMaxValue)
        {
            Application.LoadLevel(NextLevel);
        }
	}
}
