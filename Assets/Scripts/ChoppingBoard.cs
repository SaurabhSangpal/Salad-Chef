using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public Player player;
    private float TimeToCut;

    void Start()
    {
        TimeToCut = 0.0f;
    }

    void ChopChop()
    {
        if (!player.score.interactable.PollForInput() || player.score.interactable.gameobject.name != name) {
            return;
        }

        Debug.Log("Player chop: " + name);
        TimeToCut = 0.0f;
        if (player.score.Item1 != -1) {
            TimeToCut += player.score.TimeRequired[player.score.Item1];
        }
        if (player.score.Item2 != -1) {
            TimeToCut += player.score.TimeRequired[player.score.Item2];
        }
        Debug.Log("Time to cut: " + TimeToCut);
        player.score.PushToProcessed();
    }

    // Update is called once per frame
    void Update()
    {
        ChopChop();
        if (TimeToCut > 0.0f) {
            TimeToCut -= Time.deltaTime;
            player.speed = 0.0f;
        } else
            player.speed = 8.0f;
    }
}
