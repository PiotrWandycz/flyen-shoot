using UnityEngine;
using System.Collections;

public class AddHighScore : MonoBehaviour
{
    public int ScoreBonus = 100;

    void OnDisable()
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