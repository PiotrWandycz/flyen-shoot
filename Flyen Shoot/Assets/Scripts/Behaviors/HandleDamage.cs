using UnityEngine;
using System.Collections;

public class HandleDamage : MonoBehaviour
{
    //TODO: #brzydkiKod #akcesorNieChcialDzialac #głupieTłumaczenia
    private float healthPoints;
    public float HealthPoints;

    public float Damage;

    void OnEnable()
    {
        healthPoints = HealthPoints;
    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        Debug.Log("collision called from " + System.Enum.GetName(typeof(Constants.Layers), gameObject.layer) 
            + " with " + System.Enum.GetName(typeof(Constants.Layers), collidingObject.gameObject.layer));

        if (collidingObject.gameObject.GetComponent<HandleDamage>() != null)
            healthPoints -= collidingObject.gameObject.GetComponent<HandleDamage>().Damage;
    }

    void Update()
    {
        if (healthPoints <= 0)
            Die();
    }

    void Die()
    {
        if (gameObject.layer == (int)Constants.Layers.Player)
            Application.LoadLevel(Constants.Levels.MENU);

        gameObject.SetActive(false);
    }
}