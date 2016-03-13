using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{
    public float DelayTime = 5.0f;
    public float SpawnTime = 2.5f;

    public float PosXMax;
    public float PosXMin;
    public float PosY;
    public float PosYMargin;

    public int WaveMinEnemies;
    public int WaveMaxEnemies;

    public GameObject EnemyOneDir;

    public int EnemyPoolSize = 10;

    private List<GameObject> enemies;

    private System.Random rand;

    void Start()
    {
        enemies = new List<GameObject>();
        rand = new System.Random();

        // Wypełniamy listę wrogów 
        // Jeśli dojdzie kolejny typ wroga, będziemy mogli ustawić tu prawdopodobieństwo występowania, np.
        // Chcemy mieć 80% szans na spotkanie prostego wroga, czyli dodajemy 24 prostych i 6 trudnych.
        for (int i = 0; i < EnemyPoolSize; i++)
        {
            GameObject enemy = (GameObject)Instantiate(EnemyOneDir);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }

        InvokeRepeating("Spawn", DelayTime, SpawnTime);
    }

    void Spawn()
    {
        for (int i = 0; i < rand.Next(WaveMinEnemies, WaveMaxEnemies + 1); i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                float calcPosX = rand.Next(-45, 46) / 10;
                enemies[i].transform.position = new Vector3(calcPosX, (PosY + PosYMargin * i), 0.0f);
                enemies[i].SetActive(true);
            }
        }
    }
}
