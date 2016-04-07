using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddHP : MonoBehaviour
{
    public float HealthBonus = 1.0f;

    void OnDisable()
    {
        var player = GameObject.FindWithTag(Constants.Tags.PLAYER);
        var playerHandleDamage = player.GetComponent<HandleDamage>();

        playerHandleDamage.HealthPointsCurrent += HealthBonus;

        if (playerHandleDamage.HealthPointsCurrent > playerHandleDamage.HealthPointsStart)
            playerHandleDamage.HealthPointsCurrent = playerHandleDamage.HealthPointsStart;
    }
}