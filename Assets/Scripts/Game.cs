using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool Paused = false;
    private bool GameOver;
    public Player player1, player2;
    private float Timer;

    void Start()
    {
        GameOver = false;
        Timer = 300.0f;
    }

    /// <summary>
    /// Explicitly tells the game to pause
    /// </summary>
    private void PauseGame()
    {
        Paused = true;
    }

    /// <summary>
    /// End the game if any one of the players' time reaches zero or the game
    /// timer reaches zero
    /// </summary>
    private void EndGame()
    {
        if (player1.TimeLeft <= 0f || player2.TimeLeft <= 0f || Timer <= 0) {
            GameOver = true;
            PauseGame();
        }
    }

    private void DeductPointsFromPlayer()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Pause if player presses Esc, but do not toggle if GameOver is false
        if (!GameOver) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Paused = !Paused;
            }
        } else {
            Paused = true;
        }

        // Pause game if Paused is true
        Time.timeScale = Paused ? 0 : 1;

        // Update timer
        if (Timer >= 0) {
            Timer -= Time.deltaTime;
        } else {
            PauseGame();
        }
        EndGame();
    }
}
