using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    AudioSource audio;

    public AudioClip hover;
    public AudioClip click;

    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData ped)
    {
        audio.PlayOneShot(hover, 1.0f);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        audio.PlayOneShot(click, 1.0f);
    }
}