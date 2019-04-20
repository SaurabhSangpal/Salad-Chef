using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string special;

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

    public GameObject gameobject = null;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactable"))
        {
            Debug.Log(collider.name);
            gameobject = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Interactable"))
        {
            if (collider.gameObject == gameobject)
            {
                gameobject = null;
            }
        }
    }
}
