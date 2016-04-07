using UnityEngine;
using System.Collections;

public class AddExtraLife : MonoBehaviour
{
    void OnDisable()
    {
        var player = GameObject.FindWithTag(Constants.Tags.PLAYER);
        var playerData = player.GetComponent<PlayerData>();

        playerData.Lives++;
    }
}