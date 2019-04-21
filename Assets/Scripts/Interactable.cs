using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string special;
    public GameObject gameobject = null;

    void PollForInput()
    {
        if(Input.GetButtonDown(special) && gameobject)
        {
            Debug.Log("Pressed: " + special);
        }
    }

    void Update()
    {
        PollForInput();
    }

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
