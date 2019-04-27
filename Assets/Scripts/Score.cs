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
    public readonly float[] TimeRequired = new float[6] { 0.5f, 0.5f, 1.0f, 1.5f, 2.5f, 2.0f };

    private readonly short[] PointsAwarded = new short[] { 3, 3, 4, 5, 6, 6 };

    // Access customers; set within Sandbox
    public Customer[] customers = new Customer[5];
    // Stores value for the last customer whom the player has given wrong salad
    private Customer WrongCustomer;

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
    
    /// <summary>
    /// Checks if Item1 or Item2 is free and adds item to the first one that is
    /// free. If none of them is free, item is not added to the inventory.
    /// </summary>
    /// <param name="i">The value to be added to the inventory</param>
    void AddToInventory(int i)
    {
        Debug.Log("Adding to inventory: " + i);
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
            cust.CreateNewCustomer();
        } 
        else { 
            cust.GetAngry();
            DeductPoints();
            WrongCustomer = cust;
        }
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

    void DeductPoints()
    {
        PlayerScore -= 3;
    }

    /// <summary>
    /// Adds items from the inventory to ProcessedVegetables
    /// </summary>
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
