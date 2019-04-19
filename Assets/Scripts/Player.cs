using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string up, down, left, right, special;
    public float speed;
    Vector3 move;
    float vertical, horizontal;

    // Sets transformation depending on which key we have held down
    void SetMovement()
    {
        if (Input.GetKey(up))
        {
            vertical = 1;
        } else if (Input.GetKey(down))
        {
            vertical = -1;
        } else
        {
            vertical = 0;
        }
        if (Input.GetKey(right))
        {
            horizontal = 1;
        } else if (Input.GetKey(left))
        {
            horizontal = -1;
        } else
        {
            horizontal = 0;
        }
        move = new Vector2(horizontal, vertical);
        transform.position += move * speed * Time.deltaTime;
    }

    // SPACE for player 1 and RETURN for player 2
    bool SpecialKey()
    {
        if (Input.GetKey(special))
        {
            return true;
        } else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpecialKey();
        SetMovement();
    }
}
