using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationObject : MonoBehaviour
{    
    public AudioSource teleportationSound;
    public ParticleEffectManager particleManager;

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
        //teleport the xr rig to the object to teleport
        xrRig.transform.position = teleportPosition;
        //play the teleportation sound
        teleportationSound.Play();

        //activate the particle effect for 3 seconds
        particleManager.Activate();
        Invoke("DeactivateParticle", 3f);
        
    }

    void Update()
    {
        //if the user press the touchpad or the right arrow key
        if (_inputManager.TouchPad[0] > 0.5f || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //teleport the xr rig to the object to teleport
            teleport();
        }
    }
   
}
