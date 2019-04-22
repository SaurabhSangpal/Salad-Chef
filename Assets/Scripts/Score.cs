using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public string PlayerName;
    public int[] inventory = new int[2];
    // Stores the total score of a player
    public int PlayerScore;
    public Interactable interactable = null;
    // Time required to cut each element
    public float[] TimeRequired = new float[] {3.0f, 3.0f, 4.0f, 4.5f, 6.0f, 5.5f};

    void Start()
    {
        interactable = GetComponent<Interactable>();
        inventory[0] = inventory[1] = -1;
    }

    /// <summary>
    /// Checks if the player is pressing the special key and near a gameobject
    /// and then either picks up a vegetable or drops all his vegetables into
    /// the trash can.
    /// </summary>
    void CheckGameObject()
    {
        int temp;
        if (interactable.PollForInput())
        {
            switch (interactable.gameobject.name)
            {
                // Flushes the inventory when you press special on Trash_Can
                case "Trash_Can":
                    inventory[0] = inventory[1] = -1;
                    temp = 6;
                    break;
                case "Chopping_Board01":
                    if (interactable.name == "Boy")
                    {
                        // Cut the vegetables if boy(Player 1) uses left chopping board
                        Debug.Log("Chop-Chop");
                        SetScore();
                    }
                    temp = 6;
                    break;
                case "Chopping_Board02":
                    if (interactable.name == "Girl")
                    {
                        // Cut the vegetables if girl(Player 2) uses left chopping board
                        Debug.Log("Chop-Chop");
                        SetScore();
                    }
                    temp = 6;
                    break;
                default:
                    temp = 6;
                    break;
                case "Tomato":
                    temp = 0;
                    break;
                case "Potato":
                    temp = 1;
                    break;
                case "Cucumber":
                    temp = 2;
                    break;
                case "Carrot":
                    temp = 3;
                    break;
                case "Cabbage":
                    temp = 4;
                    break;
                case "Cauliflower":
                    temp = 5;
                    break;
            }
            // Use temp = 6 as a placeholder so that we don't change the value
            // of inventory elements when we don't have to
            if (temp < 6)
            {
                if (inventory[0] != -1)
	            {
	                if (inventory[1] == -1)
	                {
	                    inventory[1] = temp;
	                } else
	                {
	                    // Can't pick item
	                }
	            } else
	            {
	                inventory[0] = temp;
	            }
            }
        }
    }

    /// <summary>
    /// Sets player score. Use to display it on HUD
    /// </summary>
    void SetScore()
    {
        if (inventory[0] < 6 && inventory[0] > -1)
        {
            PlayerScore += (int)TimeRequired[inventory[0]];
        }
        if (inventory[1] < 6 && inventory[1] > -1)
        {
            PlayerScore += (int)TimeRequired[inventory[1]];
        }
        inventory[0] = inventory[1] = -1;
    }

    void Update()
    {
        CheckGameObject();
    }
}
