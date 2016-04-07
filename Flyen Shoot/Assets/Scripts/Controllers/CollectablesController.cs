using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectablesController : MonoBehaviour
{
    public List<GameObject> collectablePrefabs;

    System.Random rand;

    public void Start()
    {
        rand = new System.Random();
    }

    public void TryToSpawnCollectable(Vector3 destination, int percentChance)
    {
        if (rand.Next(100) < percentChance)
            Instantiate(collectablePrefabs[rand.Next(collectablePrefabs.Count)], destination, Quaternion.identity);
    }
}