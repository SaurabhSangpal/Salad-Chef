using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour
{
    public int[] numbers = new int[] {0, 1, 2, 3, 4, 5};
    public string VegetableName;
    public float TimeToCut;

    // Calculates the time required to cut each vegetable
    public float CalcTime() 
    { 
        return TimeToCut * Time.deltaTime;
    }

    public Vector3 ReturnPosition()
    {
        return transform.position;
    }
}
