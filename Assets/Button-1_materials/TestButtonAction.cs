using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the ButtonBehavior component attached to the GameObject
        ButtonBehavior buttonBehavior = GetComponent<ButtonBehavior>();

        // Subscribe to the button press event and define the behavior
        buttonBehavior.OnButtonPress += HandleButtonPress;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleButtonPress()
    {
        GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
        test.transform.position = new Vector3(1, 2, 1);

        Rigidbody testRb = test.AddComponent<Rigidbody>();

    }
}
