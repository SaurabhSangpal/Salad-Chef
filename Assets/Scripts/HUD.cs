using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Player player;
    Text text;
    private int score;
    private float TimeLeft = 0.0f;
    [SerializeField]
    private short DisplayValue;

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

    void GetTime()
    {
        if (TimeLeft != player.TimeLeft)
        {
            TimeLeft = player.TimeLeft;
        }
    }

    void UpdateScore()
    {
        text.text = "Score: ";
        text.text += player.score.PlayerScore;
    }

    void Update()
    {
        if (DisplayValue == 0)
        {
            UpdateScore();
        } else if (DisplayValue == 1)
        {
            GetTime();
            text.text = "";
            text.text += player.TimeLeft;
        }
    }
}
