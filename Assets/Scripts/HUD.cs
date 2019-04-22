using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Player player;
    Text text;
    private int score;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    bool GetScore()
    {
        if (score != player.score.PlayerScore)
        {
            score = player.score.PlayerScore;
            return true;
        } else
            return false;

    }

    void UpdateScore()
    {
        text.text = "Score: ";
        text.text += player.score.PlayerScore;
    }

    void Update()
    {
        UpdateScore();
        if (GetScore())
        {
            //UpdateScore();
        }
    }
}
