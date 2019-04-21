using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Customer : MonoBehaviour
{
    int[] numbers = new int[] {0, 1, 2, 3, 4, 5};
    public string[] Veg = new string[] { "Tomato", "Potato", "Cucumber", "Carrot", "Cabbage", "Cauliflower"};
    float TotalTime, time;

    // Used to create a random array that includes all the elements from Veg; we will pick the
    // first two/three elements from here as the order
    void RandomizeArray()
    {
        System.Random random = new System.Random();
        numbers = numbers.OrderBy(x => random.Next()).ToArray();
    }

    // Generates time to wait before getting angry
    void GenerateTime()
    {
        TotalTime = 0;
        // Will probably implement randomization here to choose 2 or three vegetables.
        int x = 3;
        for(int i = 0; i < x; i++)
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
    }

    // Checks if the time is over
    void TimePassed()
    {
        time += Time.deltaTime;
        if (time >= TotalTime)
        {
            // Failed the task
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        RandomizeArray();
        foreach (int x in numbers)
        {
            Debug.Log(Veg[x]);
        }
        GenerateTime();
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed();
    }
}
