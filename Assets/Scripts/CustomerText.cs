using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerText : MonoBehaviour
{
    // Set in the Sandbox
    public Customer customer;
    private Text text;
    private float CustomerTotalTime;

    // Selects the vegetables to display based on the order from Customer.numbers
    void Start()
    {
        text = GetComponent<Text>();
        text.text = null;
        UpdateText();
        
        CustomerTotalTime = customer.TotalTime;
    }

    void UpdateText()
    {
        foreach (int i in customer.items) {
            text.text += customer.Veg[i];
            text.text += ' ';
        }
    }

    void Update()
    {
        if (CustomerTotalTime != customer.TotalTime) {
            text.text = "";
            UpdateText();
            CustomerTotalTime = customer.TotalTime;
        }
    }
}
