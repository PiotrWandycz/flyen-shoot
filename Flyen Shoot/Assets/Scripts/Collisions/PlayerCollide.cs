using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collidingWith)
    {
        Debug.Log("collidedPlayer");
    }
}
