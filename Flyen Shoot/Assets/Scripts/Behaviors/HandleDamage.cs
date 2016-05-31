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

        if (HealthPointsCurrent <= 0)
            OutOfHealthPoints(collidingObject);
    }

    void OutOfHealthPoints(Collider2D collidingObject)
    {
        switch (gameObject.layer)
        {
            case (int)Constants.Layers.Player:
                new HighScoreController().InsertNewHighScore(GameObject.FindGameObjectWithTag(Constants.Tags.PLAYER).GetComponent<PlayerData>().HighScore);
                SceneManager.LoadScene(Constants.Levels.MENU);
                break;
            case (int)Constants.Layers.Enemy:
                var levelEvents = GameObject.FindWithTag(Constants.Tags.LEVEL_EVENTS);
                var collectablesController = levelEvents.GetComponent<CollectablesController>();
                collectablesController.TryToSpawnCollectable(gameObject.transform.position, 15);

                if (collidingObject.gameObject.layer == (int)Constants.Layers.Player ||
                    collidingObject.gameObject.layer == (int)Constants.Layers.PlayerBullet)
                {
                    AddHighScore(gameObject.GetComponent<EnemyData>().ScoreBonus);
                }

                Destroy(gameObject);
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }

    void AddHighScore(int ScoreBonus)
    {
        var player = GameObject.FindWithTag(Constants.Tags.PLAYER);
        var sidebar = GameObject.FindWithTag(Constants.Tags.RIGHT_SIDEBAR);

        if (player != null)
        {
            var playerData = player.GetComponent<PlayerData>();
            playerData.HighScore += ScoreBonus;
            sidebar.GetComponent<PlayerGUI>().UpdateScore(playerData.HighScore);
        }
    }
}