using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    private Rigidbody2D rigidbody;
    private Mesh meshFilter;

    private float cameraHeight;
    private float cameraWidth;
    private float unitWide;

    public GameObject LeftSidebar;
    public GameObject RightSidebar;
    private Rect leftSidebarRect;
    private Rect rightSidebarRect;
    private float leftSidebarWidth;
    private float rightSidebarWidth;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        meshFilter = GetComponent<MeshFilter>().mesh;

        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        unitWide = Camera.main.pixelWidth / 2 / cameraWidth;

        leftSidebarRect = LeftSidebar.GetComponent<RectTransform>().rect;
        rightSidebarRect = RightSidebar.GetComponent<RectTransform>().rect;
        leftSidebarWidth = leftSidebarRect.size.x / unitWide;
        rightSidebarWidth = rightSidebarRect.size.x / unitWide;
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        rigidbody.velocity = movement * Speed;
    }

    void ScreenBoundaries()
    {
        float newX = Mathf.Clamp(transform.position.x,
                         -cameraWidth + meshFilter.bounds.max.x + leftSidebarWidth,
                         cameraWidth - meshFilter.bounds.max.x - rightSidebarWidth);

        float newY = Mathf.Clamp(transform.position.y, 
                         -cameraHeight + meshFilter.bounds.max.y, 
                         cameraHeight - meshFilter.bounds.max.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}