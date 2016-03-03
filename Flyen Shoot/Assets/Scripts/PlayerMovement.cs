using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    private Rigidbody2D rigidbody;
    private Mesh meshFilter;

    private float cameraBoundX;
    private float cameraBoundY;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        meshFilter = GetComponent<MeshFilter>().mesh;

        cameraBoundY = Camera.main.orthographicSize;
        cameraBoundX = cameraBoundY * Screen.width / Screen.height;
    }

    void FixedUpdate()  
    {
        MovePlayer();
        BoundPlayer();
    } 

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rigidbody.velocity = movement * Speed;
    }

    void BoundPlayer()
    {
        Debug.Log(meshFilter.bounds.max.x);
        float newX = Mathf.Clamp(rigidbody.position.x, -cameraBoundX + meshFilter.bounds.max.x, cameraBoundX - meshFilter.bounds.max.x);
        float newY = Mathf.Clamp(rigidbody.position.y, -cameraBoundY + meshFilter.bounds.max.y, cameraBoundY - meshFilter.bounds.max.y);
        rigidbody.position = new Vector2(newX, newY);
    }
}