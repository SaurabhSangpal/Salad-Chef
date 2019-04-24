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
        if (player.score.Item1 != -1 && ItemsDisplayed < 2)
        {
            text.text += Veg[player.score.Item1];
            text.text += ' ';
            ItemsDisplayed++;
        }
        if (player.score.Item2 != -1 && ItemsDisplayed < 2)
        {
            text.text += Veg[player.score.Item2];
            text.text += ' ';
            ItemsDisplayed++;
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
