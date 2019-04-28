using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement controls
    public string up, down, left, right;
    public float speed;
    Vector3 move;
    float vertical, horizontal;

    public Score score;

    // Total time left for a player
    public float TimeLeft = 120.0f;

    /// <summary>
    /// Sets up movement depending on the public movement variables
    /// </summary>
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

    void AddBooster()
    {
        if (score.CheckBooster())
        {
            score.booster.SetBooster();
        }
    }

    void Start()
    {
        score       = GetComponent<Score>();
    }

    void Update()
    {
        SetMovement();
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        } else
            Destroy(this.gameObject);
    }
}
