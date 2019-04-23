using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public string PlayerName;
    // REFACTOR THE ENTIRE CODEBASE TO USE LIST
    public List<int> inventory = new List<int>();
    // Stores the total score of a player
    public int PlayerScore;
    public Interactable interactable = null;
    // Time required to cut each element
    public float[] TimeRequired = new float[] {3.0f, 3.0f, 4.0f, 4.5f, 6.0f, 5.5f};
    public List<int> ProcessedVegetables = new List<int>();
    // Temporary variable
    int temp;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        inventory.Capacity = 2;
        ProcessedVegetables.Capacity = 3;
        inventory.Clear();
        ProcessedVegetables.Clear();
    }

    void CheckGameObject()
    {
        if (interactable.PollForInput())
        {
            Debug.Log(interactable.gameobject.name);
            switch (interactable.gameobject.name)
            {
                default:
                    break;
                case "Trash_Can":
                    FlushInventory();
                    break;
                case "Tomato":
                    AddToInventory(0);
                    break;
                case "Potato":
                    AddToInventory(1);
                    break;
                case "Cucumber":
                    AddToInventory(2);
                    break;
                case "Carrot":
                    AddToInventory(3);
                    break;
                case "Cabbage":
                    AddToInventory(4);
                    break;
                case "Cauliflower":
                    AddToInventory(5);
                    break;
            }
        }
    }

    void FlushInventory()
    {
        inventory.Clear();
    }
    
    void AddToInventory(int i)
    {
        Debug.Log("Adding to inventory: " + i);
        if (inventory.Count < 2)
        {
            inventory.Add(i);
        }
    }

    void Update()
    {
        CheckGameObject();
    }
}
