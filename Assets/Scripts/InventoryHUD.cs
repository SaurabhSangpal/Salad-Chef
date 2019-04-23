using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public Player player;
    private Text text;
    public string[] Veg = new string[] { "Tomato", "Potato", "Cucumber", "Carrot", "Cabbage", "Cauliflower" };
    private short ItemsDisplayed;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    /// <summary>
    /// Gets value from player.score.inventory and displays it on the screen
    /// for each player
    /// </summary>
    void GetInventory()
    {
        if (player.score.inventory.Count > 0 && ItemsDisplayed < 2)
        {
            foreach (int i in player.score.inventory)
            {
                text.text += Veg[i];
                text.text += ' ';
                ItemsDisplayed++;
            }
        }
        else
        {
            //CleanInventory();
        }
    }

    void CleanInventory()
    {
        text.text = "";
    }

    void Update()
    {
        GetInventory();
    }
}
