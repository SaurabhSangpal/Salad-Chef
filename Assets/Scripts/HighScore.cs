using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static string[] HighScores { get; set; }
    private static int[] Scores { get; set; }

    void Start()
    {
        HighScores = new string[5] { "HighScore1", "HighScore2", "HighScore3", "HighScore4", "HighScore5" };
        Scores = new int[5];

        foreach (string i in HighScores) {
            if (PlayerPrefs.GetInt(i, 0) == 0) {
                Debug.Log("High score " + i + " is 0");
            }
        }
        GetScores();
    }

    /// <summary>
    /// Gets the next free slot in HighScores array; returns empty string if
    /// all array is full
    /// </summary>
    /// <returns>String Corresponding to the value in HighScores array</returns>
    public string GetNextScore()
    {
        foreach (string i in HighScores) {
            if (PlayerPrefs.GetInt(i, 0) != 0) {
                return i;
            }
        }
        return "";
    }

    /// <summary>
    /// Find where a particular value fits in the high score board
    /// </summary>
    /// <param name="Value">User high score</param>
    public void AddToHighScore(int Value)
    {
        int tmp = -1;
        for (int i = 0; i < 5; i++) {
            if (Value >= Scores[i]) {
                tmp = i;
                break;
            }
        }
        if (tmp != -1) {
            for (int i = 4; i >= tmp; i--) {
                Scores[i] = Scores[i - 1];
            }
            Scores[tmp] = Value;
        }
        // Set the high scores into the system
        for (int i = 0; i < 5; i++) {
            PlayerPrefs.SetInt(HighScores[i], Scores[i]);
        }
        PlayerPrefs.Save();
    }

    private void GetScores()
    {
        for (int i = 0; i < 5; i++) {
            Scores[i] = PlayerPrefs.GetInt(HighScores[i]);
        }
    }
}
