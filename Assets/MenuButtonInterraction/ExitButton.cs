using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    //Necessary to receive the event of the button
    private ButtonBehavior buttonBehavior;

    void Start()
    {
        //Necessary to recieve button press event
        buttonBehavior = GetComponent<ButtonBehavior>();
        buttonBehavior.OnButtonPress += HandleButtonPress;
    }

        void Update()
    {
        
    }

        private void HandleButtonPress()
    {
        //TODO : Code behavior here
        //Delete all player prefs
        PlayerPrefs.DeleteAll();
        Application.Quit();



        //Here is an example
        /*
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        Vector3 button_position = buttonBehavior.transform.position;

        cube.transform.position = button_position + new Vector3(-1.0f, 2.0f, 0.0f);

        Debug.Log("Cube created at " + cube.transform.position.ToString());

        Rigidbody cube_rigidbody = cube.AddComponent<Rigidbody>();
        */



        //Don't forget to debug.log what you did for better debugging
    }
}