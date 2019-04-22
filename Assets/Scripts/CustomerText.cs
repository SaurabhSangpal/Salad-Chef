using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerText : MonoBehaviour
{
    // Set in the Sandbox
    public Customer customer;
    private Text text;

    // Selects the vegetables to display based on the order from Customer.numbers
    void Start()
    {
        text = GetComponent<Text>();
        text.text = null;

        for (int i = 0; i < 3; i++)
        {
            text.text += customer.Veg[customer.numbers[i]];
            text.text += ' ';
        }
    }
}
