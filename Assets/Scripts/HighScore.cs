using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static string[] HighScores { get; set; }

    void Start()
    {
        HighScores = new string[5] { "HighScore1", "HighScore2", "HighScore3", "HighScore4", "HighScore5" };
        foreach (string i in HighScores)
        {
            if (PlayerPrefs.GetInt(i, 0) == 0)
            {
                Debug.Log("High score " + i + " is 0");
            }
        }
    }

    /// <summary>
    /// Gets the next free slot in HighScores array; returns empty string if
    /// all array is full
    /// </summary>
    /// <returns>String Corresponding to the value in HighScores array</returns>
    public string GetNextScore()
    {
        foreach (string i in HighScores)
        {
            if (PlayerPrefs.GetInt(i, 0) != 0)
            {
                return i;
            }
        }
        return "";
    }
}
