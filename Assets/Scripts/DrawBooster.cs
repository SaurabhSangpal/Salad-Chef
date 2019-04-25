using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawBooster : MonoBehaviour
{
    public Player player1, player2; // Assign in inspector
    private Image image;

    // Will handle the position of the displayed image
    private Vector3 move;

    public bool ShowBooster;

    void Start()
    {
        image = GetComponent<Image>();
        ShowBooster = false;
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

    void Update()
    {
        DisplayImage();
    }
}
