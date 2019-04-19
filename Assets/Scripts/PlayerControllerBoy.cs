using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bound wasd for movement. Arrow keys are not bound
public class PlayerControllerBoy : MonoBehaviour
{
    float speed = 7.6f;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Handles the key used for interaction with all game objects
    bool SpecialKey()
    {
        if (Input.GetKey("space"))
        {
            return true;
        } else
        {
            return false;
        }
    }

    void PickVegetables(Vegetables veg)
    {
        if (SpecialKey())
        {
            Vector3 temp = veg.ReturnPosition() - transform.position;
            if (temp.x <= 1.0f && temp.y <= 1.0f)
            {
                // Pick up vegetable
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpecialKey();
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}
