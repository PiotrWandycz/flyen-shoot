using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float CameraSpeed = 0.01f;

    Vector3 movement;

    void Start()
    {
        movement = new Vector3(0.0f, CameraSpeed, 0.0f); 
    }

    void FixedUpdate()
    {
        gameObject.transform.position += movement;
    }
}
