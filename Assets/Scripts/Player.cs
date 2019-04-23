using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string up, down, left, right;
    public float speed;
    Vector3 move;
    float vertical, horizontal;
    public Score score;
    // Used to calculate time to wait while cutting vegetables
    private float TimeToWait, Waiting;
    // Total time left for a player
    public float TimeLeft = 120.0f;
    private string CustomerName;
    private Customer customer;

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

    void CheckCustomer()
    {
        if (score.interactable.PollForInput())
        {
            if (score.interactable.gameobject.tag == "Customer")
            {
                // Give the produced salad
                CustomerName = score.interactable.gameobject.name;
                customer = GetComponent<Customer>();
            }
        }
    }

    void SetWaitTime()
    {
        if (score.inventory.Count > 0)
        {
            foreach (int x in score.inventory)
            {
                TimeToWait = score.TimeRequired[x];
            }
        }
    }

    void Start()
    {
        score = GetComponent<Score>();
        TimeToWait = Waiting = 0.0f;
    }

    void Update()
    {
        SetMovement();
        CheckCustomer();
        if (Waiting >= TimeToWait)
        {
            TimeToWait = Waiting = 0.0f;
            score.inventory.Clear();
            speed = 8.0f;
        }
        else
        {
            Waiting += Time.deltaTime;
            speed = 0.0f;
        }
        TimeLeft -= Time.deltaTime;
    }
}
