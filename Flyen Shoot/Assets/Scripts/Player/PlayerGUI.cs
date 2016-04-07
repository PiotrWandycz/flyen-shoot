using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    public Slider HealthSlider;

    void Start()
    {
        HealthSlider.minValue = 0.0f;
        HealthSlider.maxValue = gameObject.GetComponent<HandleDamage>().HealthPointsCurrent;
        HealthSlider.value = gameObject.GetComponent<HandleDamage>().HealthPointsCurrent;
    }

    void Update()
    {
        HealthSlider.value = gameObject.GetComponent<HandleDamage>().HealthPointsCurrent;
    }
}
