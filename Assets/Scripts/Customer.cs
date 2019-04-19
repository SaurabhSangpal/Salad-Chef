using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    List<int> numbers = new List<int>();
    public string[] Veg = new string[] { "Tomato", "Potato", "Cucumber", "Carrot", "Cabbage", "Cauliflower"};
    // Automatically generates an order
    void GenerateOrder()
    {
        int a = 0;
        for (int i = 0; i < 3; i++) { 
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
    // Start is called before the first frame update
    void Start()
    {
        GenerateOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
