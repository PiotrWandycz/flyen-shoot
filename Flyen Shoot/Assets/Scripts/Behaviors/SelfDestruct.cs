using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour 
{
    public float timer = 5.0f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
            Destroy(gameObject);
    }
}