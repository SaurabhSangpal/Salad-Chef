using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBooster : MonoBehaviour
{
    public Player player1, player2; // Assign in inspector

    // Will handle the position of the displayed image
    // Movement range : x -> -650 - 650
    //                  y -> -245 - 245
    private Vector3 move;

    public bool ShowBooster;

    void Start()
    {
        ShowBooster = false;
        PlaceImage();
    }

    /// <summary>
    /// Checks the bool ShowBooster and displays/doesn't display the image for
    /// the booster accordingly
    /// </summary>
    void DisplayBooster()
    {
        if (ShowBooster) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }

    void CheckBooster()
    {
        switch (player1.score.booster.BoosterActive) {
            default:
                break;
            case 1:
                if (name == "Speed") {
                    ShowBooster = true;
                }
                break;
            case 2:
                if (name == "Time") {
                    ShowBooster = true;
                }
                break;
            case 3:
                if (name == "Points") {
                    ShowBooster = true;
                }
                break;
        }
    }

    /// <summary>
    /// Gets a random position that the player can access and places the booster
    /// image there
    /// </summary>
    void PlaceImage()
    {
        move = new Vector3();
        move.x = Random.Range(-5.6f, 13.5f);
        move.y = Random.Range(-1.84f, 5.38f);
        move.z = 227.86f;
        transform.localPosition = move;
    }

    void Update()
    {
        DisplayBooster();
        CheckBooster();
    }
}
