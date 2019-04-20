using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    List<int> numbers = new List<int>();
    public string[] Veg = new string[] { "Tomato", "Potato", "Cucumber", "Carrot", "Cabbage", "Cauliflower"};
    float TotalTime, time;
    // Automatically generates an order
    void GenerateOrder()
    {
        int a = 0;
        // Randomly choose if we want two or three items for salad
        int x = Random.Range(2, 4);
        for (int i = 0; i < x; i++) { 
            while (a == 0)
            {
        	    a = Random.Range(0, 6);
        	    if (!numbers.Contains(a))
        	    {
        	        numbers.Add(a);
        	    } else
        	    {
        	        a = 0;
        	    }
            }
        }
    }

    // Generates time to wait before getting angry
    void GenerateTime()
    {
        TotalTime = 0;
        for (int i = 0; i < numbers.Capacity; i++)
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
        numbers.Capacity = 3;
        time = 0.0f;
        GenerateOrder();
        GenerateTime();
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed();
    }
}
