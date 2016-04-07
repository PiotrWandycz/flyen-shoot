using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public float DelayTime = 4.0f;
    public float SpawnTime = 2.5f;

    public float PosXMax;
    public float PosXMin;
    public float PosY;
    public float PosYMargin;

    public int WaveMinEnemies;
    public int WaveMaxEnemies;

    public GameObject EnemyOneDir;

    public int EnemyPoolSize = 10;

    List<GameObject> enemies;

    System.Random rand;

    void Start()
    {
        enemies = new List<GameObject>();
        rand = new System.Random();

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
