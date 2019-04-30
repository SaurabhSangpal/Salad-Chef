using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private Player player;
    private float BoosterVar = 10.0f;
    private float Timer = 10.0f;
    public short BoosterActive = 0;

    void Start()
    {
        player = GetComponent<Player>();
    }

    /// <summary>
    /// Gives twice the speed for 10 seconds
    /// </summary>
    void SpeedBooster()
    {
        Timer = 0.0f;
        player.speed *= 2;
    }

    /// <summary>
    /// Adds 20 seconds to the clock
    /// </summary>
    void TimeBooster()
    {
        player.TimeLeft += BoosterVar * 2;
    }

    /// <summary>
    /// Adds 10 points to the player
    /// </summary>
    void PointBooster()
    {
        player.score.PlayerScore += (int)BoosterVar;
    }

    /// <summary>
    /// Sets which booster to apply based on BoosterActive which will be set
    /// from another class. If BoosterActive == 0, no booster is active.
    /// </summary>
    public void SetBooster()
    {
        switch (BoosterActive) {
            default:
                break;
            case 0:
                // No booster
                break;
            case 1:
                SpeedBooster();
                break;
            case 2:
                TimeBooster();
                break;
            case 3:
                PointBooster();
                break;
        }
    }

    void Update()
    {
        if (Timer >= BoosterVar) {
            player.speed = 8.0f;
        } else {
            Timer += Time.deltaTime;
        }
    }
}
