﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public int[] numbers = new int[] {0, 1, 2, 3, 4, 5};
    public string[] Veg = new string[] { "Tomato", "Potato", "Cucumber", "Carrot", "Cabbage", "Cauliflower"};
    public  float TotalTime, time;
    // Random number between 2 and 3
    public int NumberOfElements;
    public bool StartExecuting = false;

    /// <summary>
    /// Used to create a random array that includes all the elements from Veg; we will pick the
    /// first two/three elements from here as the order
    /// </summary>
    void RandomizeArray()
    {
        System.Random random = new System.Random();
        numbers = numbers.OrderBy(x => random.Next()).ToArray();
    }

    /// <summary>
    /// Generates time to wait before getting angry
    /// </summary>
    void GenerateTime()
    {
        TotalTime = 20;
        // Randomized selection slightly favoring 3 elements
        int tmp = Random.Range(0, 10);
        int NumberOfElements;
        if (tmp > 6)
        {
            NumberOfElements = 2;
        } else
            NumberOfElements = 3;

        for(int i = 0; i < NumberOfElements; i++)
        {
            switch (numbers[i])
            {
            case 0:
                TotalTime += 5;
                break;
            case 1:
                TotalTime += 5;
                break;
            case 2:
                TotalTime += 7;
                break;
            case 3:
                TotalTime += 7;
                break;
            case 4:
                TotalTime += 9;
                break;
            case 5:
                TotalTime += 10;
                break;
            }
        }
        Debug.Log(TotalTime);
        StartExecuting = true;
    }

    /// <summary>
    /// Checks if the time is over
    /// </summary>
    void TimePassed()
    {
        time += Time.deltaTime;
        if (time >= TotalTime)
        {
            // Failed the task
        }
    }

    //Changed from Start() to Awake() so that it would be done by the time 
    // CustomerText.Start() loads
    void Awake()
    {
        //customerbar = GetComponent<CustomerBar>();
        time = 0.0f;
        RandomizeArray();
        foreach (int x in numbers)
        {
            Debug.Log(Veg[x]);
        }
        GenerateTime();
    }

    void Update()
    {
        TimePassed();
    }
}
