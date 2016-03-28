using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    private Rigidbody2D rigidbody;
    private Sprite sprite;

    private float cameraHeight;
    private float cameraWidth;
    private float unitWide;

    public GameObject LeftSidebar;
    public GameObject RightSidebar;
    private Rect leftSidebarRect;
    private Rect rightSidebarRect;
    private float leftSidebarWidth;
    private float rightSidebarWidth;

    public Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>().sprite;

        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        unitWide = Camera.main.pixelWidth / 2 / cameraWidth;

        leftSidebarRect = LeftSidebar.GetComponent<RectTransform>().rect;
        rightSidebarRect = RightSidebar.GetComponent<RectTransform>().rect;
        leftSidebarWidth = leftSidebarRect.size.x / unitWide;
        rightSidebarWidth = rightSidebarRect.size.x / unitWide;

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()  
    {
        BasicMovement();
    }

    void Update()
    {
        ScreenBoundaries();
    }

    void BasicMovement()
    {
        if (Input.GetAxis("Vertical") > 0.0f)
            animator.SetBool("MovingForward", true);
        else
            animator.SetBool("MovingForward", false);

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        rigidbody.velocity = movement * Speed;
    }

    void ScreenBoundaries()
    {
        float newX = Mathf.Clamp(transform.position.x,
                         -cameraWidth + sprite.bounds.max.x + leftSidebarWidth,
                         cameraWidth - sprite.bounds.max.x - rightSidebarWidth);

        float newY = Mathf.Clamp(transform.position.y,
                         -cameraHeight + sprite.bounds.max.y,
                         cameraHeight - sprite.bounds.max.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}