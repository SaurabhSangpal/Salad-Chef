using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterManager : MonoBehaviour
{
    public DrawBooster speed, points, time;
    public Player player1, player2;

    void ShowBooster(DrawBooster booster)
    {
        booster.gameObject.SetActive(true);
    }

    void HideBooster(DrawBooster booster)
    {
        booster.gameObject.SetActive(false);
    }

    void GetBoosterStatus(Player player)
    {
        switch (player.score.booster.BoosterActive) {
            default:
                break;
            case 1:
                ShowBooster(speed);
                break;
            case 2:
                ShowBooster(points);
                break;
            case 3:
                ShowBooster(time);
                break;
        }
    }

    void HideAllBoosters()
    {
        if (player1.score.booster.BoosterActive == 0 &&
            player2.score.booster.BoosterActive == 0) {
            HideBooster(speed);
            HideBooster(points);
            HideBooster(time);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetBoosterStatus(player1);
        GetBoosterStatus(player2);
        HideAllBoosters();
    }
}
