//using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class detectkeyObject : MonoBehaviour
{
    // This method is called when this collider/rigidbody has begun touching another rigidbody/collider

    public GameObject key;
    //add key number
     public UnityEvent onKeyTouch; // Define a new UnityEvent
    public int keyNumber = 0;
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is a key
        if (collision.gameObject == key)
        {
            // Print a message
            Debug.Log("You have the key");

            // Destroy the key
            Destroy(collision.gameObject);
              onKeyTouch?.Invoke(); // Invoke the event

            // Destroy the door
            //Destroy(gameObject);
        }
    }
}