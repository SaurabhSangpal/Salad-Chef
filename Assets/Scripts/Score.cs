using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Player inventory and score
    private int item1, item2;
    public int Item1 { get => item1; set => item1 = value; }
    public int Item2 { get => item2; set => item2 = value; }

    public List<int> ProcessedVegetables = new List<int>();
    public int PlayerScore;

    // Interactable
    public Interactable interactable = null;

    // Time required to cut each element and points awarded
    public readonly float[] TimeRequired = new[] { 0.5f, 0.5f, 1.0f, 1.5f, 2.5f, 2.0f };

    private readonly short[] PointsAwarded = new short[] { 3, 3, 4, 5, 6, 6 };

    // Access customers; set within Sandbox
    public Customer[] Customers = new Customer[5];
    // Store which customers are angry
    private List<string> AngryCustomers = new List<string>();

    // Booster class
    public Booster booster;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        booster = GetComponent<Booster>();
        Item1 = Item2 = -1;
        ProcessedVegetables.Capacity = 3;
    }

    /// <summary>
    /// Checks where a player has pressed the special key and adds the vegetables to the
    /// inventory or throws the vegetables into the trash can
    /// </summary>
    void CheckGameObject()
    {
        if (interactable.PollForInput()) {
            //Debug.Log(interactable.gameobject.name);
            switch (interactable.gameobject.name) {
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
        if (Item1 == -1) {
            Item1 = i;
        } else {
            if (Item2 == -1) {
                Item2 = i;
            } else {
                Debug.Log("Inventory full!");
            }
        }
    }

    /// <summary>
    /// Find the correct customer where the user has pressed their special
    /// key and then award/deduct points accordingly
    /// </summary>
    void GetCustomer()
    {
        if (interactable.PollForInput() && interactable.gameobject.tag == "Customer") {
            string GameObjectName = interactable.gameobject.name;
            switch (GameObjectName.Last()) {
                default:
                    break;
                case '1':
                    ProcessCustomer(Customers[0]);
                    break;
                case '2':
                    ProcessCustomer(Customers[1]);
                    break;
                case '3':
                    ProcessCustomer(Customers[2]);
                    break;
                case '4':
                    ProcessCustomer(Customers[3]);
                    break;
                case '5':
                    ProcessCustomer(Customers[4]);
                    break;
            }
        }
    }

    /// <summary>
    /// Check if a customer leaves and check if the customer was angry with
    /// the player
    /// </summary>
    void CheckIfCustomerLeaves()
    {
        foreach (Customer cust in Customers) {
            if (cust.DeductPoints > 0 && !cust.isAngry) {
                DeductPoints();
                cust.DeductPoints--;
            } else if (cust.DeductPoints > 0 && AngryCustomers.Contains(cust.name)) {
                DeductPoints();
                DeductPoints();
                _ = AngryCustomers.Remove(cust.name);
                cust.DeductPoints--;
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
        for (int i = 0; i < 3; i++) {
            if (!ProcessedVegetables.Contains(cust.items[i])) {
                tmp = false;
            }
        }
        if (tmp) {
            AwardPoints();
            // Pick a random booster
            Debug.Log((cust.time / cust.TotalTime) * 100);
            if ((cust.time / cust.TotalTime * 100) > 30) {
                booster.BoosterActive = (short)Random.Range(1, 4);
            }
            cust.CreateNewCustomer();
        } else {
            cust.GetAngry();
            if (!AngryCustomers.Contains(cust.name)) { 
                AngryCustomers.Add(cust.name);
            }
        }
        ProcessedVegetables.Clear();
    }

    /// <summary>
    /// If player gives the correct combination to the customer, he is awarded
    /// points based on the time required to cut them
    /// </summary>
    void AwardPoints()
    {
        foreach (int i in ProcessedVegetables) {
            PlayerScore += (int)PointsAwarded[i];
        }
    }

    /// <summary>
    /// Removes points when player gives incorrect combination to the customer
    /// </summary>
    void DeductPoints() => PlayerScore -= 3;

    /// <summary>
    /// Adds items from the inventory to ProcessedVegetables
    /// </summary>
    public void PushToProcessed()
    {
        if (Item1 != -1) {
            ProcessedVegetables.Add(Item1);
            if (Item2 != -1) {
                ProcessedVegetables.Add(Item2);
            }
        }
        FlushInventory();
    }

    public bool CheckBooster()
    {
        if (interactable.PollForInput()) {
            if (interactable.gameobject.tag == "Booster") {
                // Is a booster, pick it up
                booster.SetBooster();
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        CheckGameObject();
        CheckBooster();
        GetCustomer();
        CheckIfCustomerLeaves();
        // Check if Processed Vegetables go above 3 and then remove the last element if it
        // does
        if (ProcessedVegetables.Count > 3) {
            _ = ProcessedVegetables.Remove(ProcessedVegetables.Count);
        }
    }
}
