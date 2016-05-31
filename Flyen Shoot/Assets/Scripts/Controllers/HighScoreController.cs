using UnityEngine;
using System.Collections.Generic;

public class HighScoreController : MonoBehaviour
{
    public void CheckIfHighscoresExist()
    {
        var firstScore = PlayerPrefs.GetString("HSK0");
        if (string.IsNullOrEmpty(firstScore))
        {
            var hs = SeedHighscores();
            SetHighscores(hs);
        }
    }

    void SetHighscores(List<KeyValuePair<string, int>> hs)
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("HSK" + i, hs[i].Key);
            PlayerPrefs.SetInt("HSV" + i, hs[i].Value);
        }
    }

    List<KeyValuePair<string, int>> SeedHighscores()
    {
        var hs = new List<KeyValuePair<string, int>>();

        hs.Add(new KeyValuePair<string, int>("Maverick", 10000));
        hs.Add(new KeyValuePair<string, int>("Viper", 9000));
        hs.Add(new KeyValuePair<string, int>("Iceman", 8000));
        hs.Add(new KeyValuePair<string, int>("Jester", 7000));
        hs.Add(new KeyValuePair<string, int>("Goose", 6000));
        hs.Add(new KeyValuePair<string, int>("Cougar", 5000));
        hs.Add(new KeyValuePair<string, int>("Wolfman", 4000));
        hs.Add(new KeyValuePair<string, int>("Hollywood", 3000));
        hs.Add(new KeyValuePair<string, int>("Slider", 2000));
        hs.Add(new KeyValuePair<string, int>("Chipper", 1000));

        return hs;
    }

    public void InsertNewHighScore(int playerScore)
    {
        var hs = new List<KeyValuePair<string, int>>();

        for (int i = 0; i < 10; i++)
        {
            hs.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("HSK" + i), PlayerPrefs.GetInt("HSV" + i)));
        }

        for (int i = 0; i < 10; i++)
        {
            if (playerScore > hs[i].Value)
            {
                hs.Insert(i, new KeyValuePair<string, int>(PlayerPrefs.GetString("PlayerName"), playerScore));
                break;
            }
        }

        SetHighscores(hs);
    }
}
