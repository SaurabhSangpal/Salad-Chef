using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public string PlayerName;
    public int[] inventory = new int[2];
    // Stores the total score of a player
    public int PlayerScore;

    Interactable interactable = null;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        inventory[0] = inventory[1] = -1;
    }

    void CheckGameObject()
    {
        int temp;
        if (interactable.PollForInput())
        {
            switch (interactable.gameobject.name)
            {
                default:
                    temp = -1;
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

    // Update is called once per frame
    void Update()
    {
        CheckGameObject();
    }
}
