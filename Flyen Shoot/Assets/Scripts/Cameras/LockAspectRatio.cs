using UnityEngine;
using System.Collections;

public class LockAspectRatio : MonoBehaviour
{
    // via http://gamedesigntheory.blogspot.com/2010/09/controlling-aspect-ratio-in-unity.html
    public float heightRatio = 4.0f;
    public float widthRatio = 3.0f;

    void Awake()
    {
        float targetAspect = heightRatio / widthRatio;
        float windowAspect = Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}