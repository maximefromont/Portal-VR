using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    //Necessary to receive the event of the button
    private ButtonBehavior buttonBehavior;
    private bool OnDebug;
    public GameObject console;

    void Start()
    {
        //Necessary to recieve button press event
        buttonBehavior = GetComponent<ButtonBehavior>();
        buttonBehavior.OnButtonPress += HandleButtonPress;
        OnDebug = Convert.ToBoolean(PlayerPrefs.GetInt("DebugMode"));
        Debug.Log("DebugMode : " + OnDebug);

    }

        void Update()
    {
        
    }

        private void HandleButtonPress()
    {
        //TODO : Code behavior here

        OnDebug = !OnDebug;
        PlayerPrefs.SetInt("DebugMode", Convert.ToInt32(OnDebug));
        Debug.Log("DebugMode : " + OnDebug);
        console.gameObject.SetActive(OnDebug);
        

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
