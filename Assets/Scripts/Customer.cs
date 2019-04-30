using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Set used for randomization and set used to store final items after randomization
    public int[] numbers = new[] { 0, 1, 2, 3, 4, 5 };
    public int[] items = new int[3];

    // Set of vegetable names
    public string[] Veg = new string[] { "Tomato", "Potato", "Cucumber", "Carrot", "Cabbage", "Cauliflower" };

    // Total time before the customer leaves, and a timer that counts upwards until TotalTime
    public float TotalTime, time;

    // Used for randomization
    System.Random random;

    // Check if the customer is angry, used in Player.cs or Score.cs
    public bool isAngry;
    public short DeductPoints = 0;

    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Used to create a random array that includes all the elements from Veg; we will pick the
    /// first two/three elements from here as the order
    /// </summary>
    void RandomizeArray()
    {
        numbers = numbers.OrderBy(x => random.Next()).ToArray();
        for (int i = 0; i < 3; i++) {
            items[i] = numbers[i];
        }
    }

    /// <summary>
    /// Generates time to wait before getting angry
    /// </summary>
    void GenerateTime()
    {
        TotalTime = 30.0f;
        for (int i = 0; i < 3; i++) {
            switch (numbers[i]) {
            default:
                break;
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
    }

    /// <summary>
    /// Checks if the time is over
    /// </summary>
    void TimePassed()
    {
        time += Time.deltaTime;
        if (time >= TotalTime) {
            DeductPoints = 2;
            CreateNewCustomer();
        }
    }

    // If player brings the wrong salad, execute
    public void GetAngry()
    {
        isAngry = true;
        TotalTime /= 2;
    }

    //Changed from Start() to Awake() so that it would be done by the time 
    // CustomerText.Start() loads
    void Awake()
    {
        CreateNewCustomer();
    }

    public void CreateNewCustomer()
    {
        // Using GUID as seed to generate random numbers
        random = new System.Random(int.Parse(System.Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
        time = TotalTime = 0.0f;
        RandomizeArray();
        GenerateTime();
        isAngry = false;
        Debug.Log("Customer Created");
    }

    void Update()
    {
        TimePassed();
    }
}
