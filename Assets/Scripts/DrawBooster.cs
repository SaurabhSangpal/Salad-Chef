using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBooster : MonoBehaviour
{
    // Will handle the position of the displayed image
    private Vector3 move;

    public bool ShowBooster;

    void Start()
    {
        ShowBooster = false;
        PlaceImage();
    }

    /// <summary>
    /// Gets a random position that the player can access and places the booster
    /// image there
    /// </summary>
    void PlaceImage()
    {
        move = new Vector2();
        move.x = Random.Range(2.30f, 21.0f);
        move.y = Random.Range(3.0f, 10.0f);
        transform.localPosition = move;
    }
}
