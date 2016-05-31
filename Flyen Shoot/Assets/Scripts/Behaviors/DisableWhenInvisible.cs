using UnityEngine;
using System.Collections;

public class DisableWhenInvisible : MonoBehaviour
{
    Renderer renderer;

    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}