using UnityEngine;
using System.Collections;

public class MoveOneDirection : MonoBehaviour 
{
    public float Speed = 5.0f;
    public Constants.Direction direction;

    private Rigidbody2D rigidbody;
    private Vector3 movement;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        switch (direction)
        {
            case Constants.Direction.Up:
                movement = new Vector3(0.0f, 1.0f, 0.0f); 
                break;
            case Constants.Direction.Down:
                movement = new Vector3(0.0f, -1.0f, 0.0f); 
                break;
            case Constants.Direction.Left:
                movement = new Vector3(-1.0f, 0.0f, 0.0f); 
                break;
            case Constants.Direction.Right:
                movement = new Vector3(1.0f, 0.0f, 0.0f); 
                break;
            case Constants.Direction.UpLeft:
                movement = new Vector3(-1.0f, 1.0f, 0.0f);
                break;
            case Constants.Direction.UpRight:
                movement = new Vector3(1.0f, 1.0f, 0.0f);
                break;
            case Constants.Direction.DownLeft:
                movement = new Vector3(-1.0f, -1.0f, 0.0f);
                break;
            case Constants.Direction.DownRight:
                movement = new Vector3(1.0f, -1.0f, 0.0f);
                break;
        }
        rigidbody.velocity = movement * Speed;
    }
}