﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Player player;
    Text text;
    private int score;
    private float TimeLeft = 0.0f;
    public short DisplayValue;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    // Will be used to optimize so that we would not read from player.score
    // when we don't need to
    bool GetScore()
    {
        if (score != player.score.PlayerScore) {
            score = player.score.PlayerScore;
            return true;
        } else {
            return false;
        }

    }

    void GetTime()
    {
        if (TimeLeft != player.TimeLeft) {
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
        if (DisplayValue == 0) {
            UpdateScore();
        } else if (DisplayValue == 1) {
            GetTime();
            text.text = player.TimeLeft.ToString("0.0");
        }
    }
}
