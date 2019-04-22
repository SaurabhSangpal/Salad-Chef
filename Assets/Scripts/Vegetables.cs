using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetables : MonoBehaviour
{
    public int[] numbers = new int[] {0, 1, 2, 3, 4, 5};
    public string VegetableName;
    public float TimeToCut;
    // idk if I will use this enum, but have declared it nonetheless. Would be
    // helpful while cleaning up spaghetti code
    public enum Items { Tomato, Potato, Cucumber, Carrot, Cabbage, Cauliflower };

    // Calculates the time required to cut each vegetable
    public float CalcTime() 
    { 
        return TimeToCut * Time.deltaTime;
    }
}
