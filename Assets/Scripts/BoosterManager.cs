using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterManager : MonoBehaviour
{
    public DrawBooster speed, time, points;
    public Player player;

    /// <summary>
    /// Shows the booster that we want to
    /// </summary>
    /// <param name="booster">Speed, time or points</param>
    void ShowBooster(DrawBooster booster)
    {
        booster.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the booster that we want to
    /// </summary>
    /// <param name="booster">Speed, time or points</param>
    void HideBooster(DrawBooster booster)
    {
        booster.gameObject.SetActive(false);
    }

    /// <summary>
    /// If Booster.BoosterActive = 0, hide all boosters,
    /// else display the corresponding booster
    /// </summary>
    /// <param name="player"></param>
    void GetBoosterStatus(Player player)
    {
        switch (player.score.booster.BoosterActive) {
            default:
                break;
            case 0:
                HideAllBoosters();
                break;
            case 1:
                ShowBooster(speed);
                break;
            case 2:
                ShowBooster(time);
                break;
            case 3:
                ShowBooster(points);
                break;
        }
    }

    /// <summary>
    /// Hides all boosters
    /// </summary>
    void HideAllBoosters()
    {
        HideBooster(speed);
        HideBooster(points);
        HideBooster(time);
    }

    // Update is called once per frame
    void Update()
    {
        GetBoosterStatus(player);
    }
}
