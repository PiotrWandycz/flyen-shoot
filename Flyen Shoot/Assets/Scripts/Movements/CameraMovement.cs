using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float CameraSpeed = 0.01f;

    Vector3 movement;

    void Start()
    {
        movement = Vector3.up * CameraSpeed;
    }

    void Update()
    {
        gameObject.transform.Translate(movement * Time.deltaTime, Space.Self);
    }
}
