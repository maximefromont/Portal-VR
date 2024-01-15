using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationObject : MonoBehaviour
{
    public AudioSource teleportationSound;


    public GameObject xrRig;
    public GameObject objectToTeleport;

    private InputManager _inputManager;

    private void Awake() => _inputManager = InputManager.Instance;

    //teleportation function to teleport the xr rig to the object to teleport
    public void teleport()
    {
        //get the position of the object to teleport
        Vector3 teleportPosition = objectToTeleport.transform.position;
        //get the position of the xr rig
        Vector3 xrRigPosition = xrRig.transform.position;
        //get the difference between the two positions
        Vector3 difference = teleportPosition - xrRigPosition;
        //teleport the xr rig to the object to teleport one metter above
        xrRig.transform.position = teleportPosition + new Vector3(0, 1, 0);
        //play the teleportation sound
        teleportationSound.Play();




    }

    void Update()
    {
        //if the user press the touchpad or the right arrow key
        if (_inputManager.IsPressButton || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //teleport the xr rig to the object to teleport
            teleport();
        }
    }

}
