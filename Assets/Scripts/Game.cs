using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private bool Paused = false;
    [SerializeField]
    Player player1, player2;
    [SerializeField]
    Text gametimer;

    /// <summary>
    /// Explicitly tells the game to pause
    /// </summary>
    public void PauseGame()
    {
        Paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
        }
        if (Paused)
        {
            Time.timeScale = 0;
        } else
            Time.timeScale = 1;
    }
}
