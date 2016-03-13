using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == (int)Constants.Layers.Player)
            gameObject.SetActive(false);
    }
}