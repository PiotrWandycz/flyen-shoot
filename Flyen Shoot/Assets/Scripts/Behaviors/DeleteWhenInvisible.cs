using UnityEngine;
using System.Collections;

public class DeleteWhenInvisible : MonoBehaviour
{
    Renderer renderer;

    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}