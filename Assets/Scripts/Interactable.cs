using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string special;
    public GameObject gameobject = null;

    /// <summary>
    /// Returns true if we are near a valid gameobject and are pressing the special key
    /// Used in Score.cs
    /// </summary>
    public bool PollForInput()
    {
        if(Input.GetButtonDown(special) && gameobject)
        {
            Debug.Log("Pressed: " + special);
            return true;
        } else
            return false;
    }

    /// <summary>
    /// Tests if we enter the collider of an object marked as Interactable or Customer
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactable"))
        {
            Debug.Log(collider.name);
            gameobject = collider.gameObject;
        } else if (collider.CompareTag("Customer"))
        {
            Debug.Log("Customer: " + collider.name);
            gameobject = collider.gameObject;
        }
    }

    /// <summary>
    /// Tests if we exit the collider of an object after entering it first using
    /// OnTriggerEnter2D method.
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactable") || collider.CompareTag("Customer"))
        {
            if (collider.gameObject == gameobject)
            {
                gameobject = null;
            }
        }
    }
}
