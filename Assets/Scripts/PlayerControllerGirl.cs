using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bound the numpad keys for movement.
public class PlayerControllerGirl : MonoBehaviour
{
    float speed = 8.0f;
    Vector3 move;
    float vertical, horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Handles the key used for interaction with all game objects
    bool SpecialKey()
    {
        if (Input.GetKey("return"))
        {
            return true;
        } else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpecialKey();
        if (Input.GetKey("up"))
        {
            // Move up
            vertical = 1;
        } else if (Input.GetKey("down"))
        {
            // Move down
            vertical = -1;
        } else { vertical = 0; }
        if (Input.GetKey("left"))
        {
            // Move left
            horizontal = -1;
        } else if (Input.GetKey("right"))
        {
            // Move right
            horizontal = 1;
        } else { horizontal = 0; }
        move = new Vector2(horizontal, vertical);
        transform.position += move * speed * Time.deltaTime;
    }
}
