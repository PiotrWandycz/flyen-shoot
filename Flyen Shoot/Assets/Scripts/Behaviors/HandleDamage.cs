using UnityEngine;
using System.Collections;

public class HandleDamage : MonoBehaviour
{
    private float healthPoints;
    public float HealthPoints;

    public float Damage;

    void OnEnable()
    {
        healthPoints = HealthPoints;
    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.GetComponent<HandleDamage>() != null)
            healthPoints -= collidingObject.gameObject.GetComponent<HandleDamage>().Damage;
    }

    void Update()
    {
        if (healthPoints <= 0)
            OutOfHealthPoints();
    }

    void OutOfHealthPoints()
    {
        switch (gameObject.layer)
        {
            case (int)Constants.Layers.Player:
                Application.LoadLevel(Constants.Levels.MENU);
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }
}