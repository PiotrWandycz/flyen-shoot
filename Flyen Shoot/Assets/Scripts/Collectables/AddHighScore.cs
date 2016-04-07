﻿using UnityEngine;
using System.Collections;

public class AddHighScore : MonoBehaviour 
{
    public int ScoreBonus = 100;

    void OnDisable()
    {
        var player = GameObject.FindWithTag(Constants.Tags.PLAYER);
        var playerData = player.GetComponent<PlayerData>();

        playerData.HighScore += ScoreBonus;
    }
}