using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubeOnButtonPress : MonoBehaviour
{

    private ButtonBehavior buttonBehavior;

    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        //USE THIS TO KNOW WHEN THE BUTTON IS PRESSED
        // Get the ButtonBehavior component attached to the GameObject
        buttonBehavior = GetComponent<ButtonBehavior>();

        // Subscribe to the button press event and define the behavior
        buttonBehavior.OnButtonPress += HandleButtonPress;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleButtonPress()
    {
        if(cube != null)
        {
            Destroy(cube);
        }
        
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        //Make sure to get the local position of the button
        Vector3 button_position = buttonBehavior.transform.position;

        cube.transform.position = button_position + new Vector3(0.0f, 4.0f, 1.0f);

        print("Button pressed! Cube created at " + cube.transform.position.ToString());

        //Add physic to the cube
        Rigidbody cube_rigidbody = cube.AddComponent<Rigidbody>();

    }
}
