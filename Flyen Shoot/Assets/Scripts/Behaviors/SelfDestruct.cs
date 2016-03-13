using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{
    public float LifeTime;

    void OnEnable()
    {
        Invoke("Destroy", LifeTime);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}