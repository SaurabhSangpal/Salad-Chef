using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool Paused = false;
    public Player player1, player2;
    private float Timer;

    void Start()
    {
        Timer = 300.0f;
    }

    /// <summary>
    /// Explicitly tells the game to pause
    /// </summary>
    private void PauseGame()
    {
        Paused = true;
    }

    private void EndGame()
    {
        if (player1.TimeLeft <= 0f || player2.TimeLeft <= 0f)
        {
            PauseGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Pause if player presses Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
        }
        if (Paused)
        {
            Time.timeScale = 0;
        } else
            Time.timeScale = 1;

        // Update timer
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        } else
            PauseGame();
        EndGame();
    }
}
