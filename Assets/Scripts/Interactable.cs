using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #if xd
public float radius = 2.0f, offsetX, offsetY;
    Vector3 location;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        location.x = transform.position.x + offsetX;
        location.y = transform.position.y + offsetY;
        location.z = transform.position.z;
        Gizmos.DrawSphere(location, radius);
    }
#endif

    public string special;

    void Update()
    {
        if (Input.GetButtonDown(special) && gameobject)
        {
            Debug.Log("Pressed special key");
        }
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
