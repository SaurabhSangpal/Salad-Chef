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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("[8]"))
        {
            // Move up
            vertical = 1;
        } else if (Input.GetKey("[2]"))
        {
            // Move down
            vertical = -1;
        } else { vertical = 0; }
        if (Input.GetKey("[4]"))
        {
            // Move left
            horizontal = -1;
        } else if (Input.GetKey("[6]"))
        {
            // Move right
            horizontal = 1;
        } else { horizontal = 0; }
        move = new Vector2(horizontal, vertical);
        transform.position += move * speed * Time.deltaTime;
    }
}
