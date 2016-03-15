﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour 
{
    public GameObject BulletPrefab;
    public int MaxBullets = 25;

    private List<GameObject> bullets;

    public float reloadTime = 0.1f;
    float cooldownTimer = 0.0f;

    void Start()
    {
        bullets = new List<GameObject>();

        for (int i = 0; i < MaxBullets; i++)
        {
            GameObject bullet = (GameObject)Instantiate(BulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    void FixedUpdate()
    {
        if (cooldownTimer > 0.0f)
            cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = reloadTime;

            for (int i = 0; i < MaxBullets; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, 0.0f);
                    bullets[i].SetActive(true);
                    break;
                }
            }
        }
    }
}
