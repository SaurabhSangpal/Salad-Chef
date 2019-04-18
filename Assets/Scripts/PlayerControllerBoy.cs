using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bound wasd for movement. Arrow keys are not bound
public class PlayerControllerBoy : MonoBehaviour
{
    float speed = 7.6f;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}
