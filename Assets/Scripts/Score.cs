using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    public List<int> inventory;
    // Stores the total score of a player
    public int PlayerScore;
    public Interactable interactable = null;
    // Time required to cut each element
    public float[] TimeRequired = new float[] {3.0f, 3.0f, 4.0f, 4.5f, 6.0f, 5.5f};
    public List<int> ProcessedVegetables;
    // Access customers; set within Sandbox
    public Customer[] customers = new Customer[5];

    void Start()
    {
        interactable = GetComponent<Interactable>();
        inventory = new List<int>();
        ProcessedVegetables = new List<int>();
        inventory.Capacity = 2;
        ProcessedVegetables.Capacity = 3;
    }

    void CheckGameObject()
    {
        if (interactable.PollForInput())
        {
            //Debug.Log(interactable.gameobject.name);
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
        inventory.Add(i);
    }

    /// <summary>
    /// Find the correct customer where the user has pressed their special
    /// key and then award/deduct points accordingly
    /// </summary>
    void GetCustomer()
    {
        if (interactable.PollForInput() && interactable.gameobject.tag == "Customer")
        {
            string GameObjectName = interactable.gameobject.name;
            switch (GameObjectName.Last())
            {
                default:
                    break;
                case '1':
                    ProcessCustomer(customers[0]);
                    break;
                case '2':
                    ProcessCustomer(customers[1]);
                    break;
                case '3':
                    ProcessCustomer(customers[2]);
                    break;
                case '4':
                    ProcessCustomer(customers[3]);
                    break;
                case '5':
                    ProcessCustomer(customers[4]);
                    break;
            }
        }
    }

    /// <summary>
    /// Check if player has created the correct salad for given customer and
    /// award points accordingly
    /// </summary>
    /// <param name="cust"></param>
    void ProcessCustomer(Customer cust)
    {
        bool tmp = true;
        for (int i = 0; i < 3; i++)
        {
            if (!ProcessedVegetables.Contains(cust.items[i]))
            {
                tmp = false;
            }
        }
        if (tmp)
        {
            AwardPoints();
        } else
            cust.GetAngry();
        ProcessedVegetables.Clear();
    }

    /// <summary>
    /// If player gives the correct combination to the customer, he is awarded
    /// points based on the time required to cut them
    /// </summary>
    void AwardPoints()
    {
        foreach (int i in ProcessedVegetables)
        {
            PlayerScore += (int)TimeRequired[i];
        }
    }

    void Update()
    {
        CheckGameObject();
        GetCustomer();
    }
}
