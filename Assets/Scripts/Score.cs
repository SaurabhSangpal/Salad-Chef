using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Player inventory and score
    public int Item1, Item2;
    public List<int> ProcessedVegetables = new List<int>();
    public int PlayerScore;

    // Interactable
    public Interactable interactable = null;

    // Time required to cut each element and points awarded
    public float[] TimeRequired = new float[] { 1.0f, 1.0f, 2.0f, 2.5f, 4.0f, 3.5f };
    private short[] PointsAwarded = new short[] { 3, 3, 4, 5, 6, 6 };

    // Access customers; set within Sandbox
    public Customer[] customers = new Customer[5];

    void Start()
    {
        interactable = GetComponent<Interactable>();
        Item1 = Item2 = -1;
        ProcessedVegetables.Capacity = 3;
    }

    /// <summary>
    /// Checks where a player has pressed the special key and adds the vegetables to the
    /// inventory or throws the vegetables into the trash can
    /// </summary>
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

    /// <summary>
    /// Clears the inventory
    /// </summary>
    public void FlushInventory()
    {
        //Inventory.Clear();
        Item1 = Item2 = -1;
    }
    
    void AddToInventory(int i)
    {
        Debug.Log("Adding to inventory: " + i);
        //Inventory.Add(i);
        if (Item1 == -1)
        {
            Item1 = i;
        }
        else
        {
            if (Item2 == -1)
            {
                Item2 = i;
            } else
                Debug.Log("Inventory full!");
        }
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
            PlayerScore += (int)PointsAwarded[i];
        }
    }

    public void PushToProcessed()
    {
        if (Item1 != -1)
        {
            ProcessedVegetables.Add(Item1);
            if (Item2 != -1)
            {
                ProcessedVegetables.Add(Item2);
            }
        }
        FlushInventory();
    }

    void Update()
    {
        CheckGameObject();
        GetCustomer();
        // Check if Processed Vegetables go above 3 and then remove the last element if it
        // does
        if (ProcessedVegetables.Count > 3)
        {
            _ = ProcessedVegetables.Remove(ProcessedVegetables.Count);
        }
    }
}
