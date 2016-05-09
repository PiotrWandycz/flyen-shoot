using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HandleDamage : MonoBehaviour
{
    public float HealthPointsStart;
    public float HealthPointsCurrent;

    public float Damage;

    public object SceneManagerConstants { get; private set; }

    void OnEnable()
    {
        HealthPointsCurrent = HealthPointsStart;
    }

    void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (collidingObject.gameObject.GetComponent<HandleDamage>() != null)
            HealthPointsCurrent -= collidingObject.gameObject.GetComponent<HandleDamage>().Damage;
    }

    void Update()
    {
        if (HealthPointsCurrent <= 0)
            OutOfHealthPoints();
    }

    void OutOfHealthPoints()
    {
        switch (gameObject.layer)
        {
            case (int)Constants.Layers.Player:
                SceneManager.LoadScene(Constants.Levels.MENU);
                break;
            case (int)Constants.Layers.Enemy:
                var levelEvents = GameObject.FindWithTag(Constants.Tags.LEVEL_EVENTS);
                var collectablesController = levelEvents.GetComponent<CollectablesController>();
                collectablesController.TryToSpawnCollectable(gameObject.transform.position, 10);
                gameObject.SetActive(false);
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }
}