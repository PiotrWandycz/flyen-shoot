using UnityEngine;
using System.Collections;

public class KamikazeMovement : MonoBehaviour
{
    public float XAxisSpeed = 2.0f;
    public float YAxisSpeed = 1.5f;

    Renderer renderer;
    Rigidbody2D rigidbody;
    Vector3 movement;

    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (renderer.isVisible)
        {
            movement = new Vector3(FollowPlayer(YAxisSpeed), -1.0f, 0.0f);
            rigidbody.velocity = movement * XAxisSpeed;
        }
    }

    float FollowPlayer(float AxisYSpeed)
    {
        var player = GameObject.FindWithTag(Constants.Tags.PLAYER);

        if (player.transform.position.x > gameObject.transform.position.x)
        {
            return AxisYSpeed;
        }
        else if (player.transform.position.x < gameObject.transform.position.x)
        {
            return -AxisYSpeed;
        }
        else
        {
            return 0.0f;
        }
    }
}