using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //Necessary to receive the event of the button
    private ButtonBehavior buttonBehavior;
    public string sceneName;

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

        Debug.Log("Change scene to "+sceneName);
        // Change scene to level-1_tutorial-1
        SceneManager.LoadScene(sceneName);



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
