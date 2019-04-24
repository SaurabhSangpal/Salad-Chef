using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public Player player;
    private float TimeToCut;

    void ChopChop()
    {
        if (player.score.interactable.PollForInput() && player.score.interactable.gameobject.name == this.name)
        {
            Debug.Log("Player chop: " + this.name);
            Choppy();
        }
    }

    void Choppy()
    {
        TimeToCut = 0.0f;
        if (player.score.Item1 != -1)
        {
            CalculateTime((short)player.score.Item1);
        }
        if (player.score.Item2 != -1)
        {
            CalculateTime((short)player.score.Item2);
        }
        player.score.PushToProcessed();
    }

    void CalculateTime(short x)
    {
        TimeToCut += player.score.TimeRequired[x];
        Debug.Log("Time to cut: " + TimeToCut);
    }

    void PauseMovement()
    {
        if (TimeToCut > 0.0f)
        {
            TimeToCut -= Time.deltaTime;
            player.speed = 0.0f;
        }
        else
        {
            player.speed = 8.0f;
        }
    }

    void Start()
    {
        TimeToCut = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChopChop();
        PauseMovement();
    }
}
