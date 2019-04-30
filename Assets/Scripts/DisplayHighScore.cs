using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    private HighScore hs;
    private TextMeshProUGUI text;
    private string[] HighScores = new string[] { "HighScore1", "HighScore2", "HighScore3", "HighScore4", "HighScore5" };

    void Start()
    {
        hs = GetComponent<HighScore>();
        text = GetComponent<TextMeshProUGUI>();
        DisplayScore();
    }

    void DisplayScore()
    {
        text.text = "";
        for (int i = 0; i < 5; i++) {
            text.text += i + 1;
            text.text += "                ";
            text.text += PlayerPrefs.GetInt(HighScores[i]);
            text.text += "\n";
        }
    }
}
