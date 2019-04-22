using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerBar : MonoBehaviour
{
    public Customer customer;
    public Image CustomerBarForeground;

    private float time = 1;

    void Start()
    {
        CustomerBarForeground = GetComponent<Image>();
        UpdateCustomerBar();
    }

    /// <summary>
    /// Checks Customer.TotalTime and time elapsed since starting the script
    /// and draws the UI element accordingly
    /// </summary>
    private void UpdateCustomerBar()
    {
        if (time < customer.TotalTime)
        {
            time += Time.deltaTime;
            float ratio = time / customer.TotalTime;
            CustomerBarForeground.fillAmount = ratio;
        }
    }

    void Update()
    {
        UpdateCustomerBar();
    }
}
