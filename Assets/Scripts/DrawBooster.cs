using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawBooster : MonoBehaviour
{
    public Player player1, player2; // Assign in inspector
    private Image image;

    // Will handle the position of the displayed image
    // Movement range : x -> -650 - 650
    //                  y -> -245 - 245
    private Vector3 move;

    public bool ShowBooster;

    void Start()
    {
        image = GetComponent<Image>();
        ShowBooster = false;
        PlaceImage();
    }

    /// <summary>
    /// Checks the bool ShowBooster and displays/doesn't display the image for
    /// the booster accordingly
    /// </summary>
    void DisplayImage()
    {
        if (ShowBooster)
        {
            image.gameObject.SetActive(true);
        }
        else
        {
            image.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Gets a random position that the player can access and places the booster
    /// image there
    /// </summary>
    void PlaceImage()
    {
        move = new Vector2();
        move.x = Random.Range(-650, 651);
        move.y = Random.Range(-245, 246);
        image.rectTransform.localPosition = move;
    }

    void Update()
    {
        DisplayImage();
    }
}
