using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TriggerButtonWatcher : MonoBehaviour
{

    private InputDevice leftController;
    private bool wasPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        foreach(InputDevice device in devices){
            Debug.Log(device.name + " " + device.characteristics);
            if(device.characteristics.HasFlag(InputDeviceCharacteristics.Left)){
                leftController = device;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool tmpState = false;
        if(leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue) && triggerButtonValue){               
                tmpState = true;
        }
        
        if(tmpState != wasPressed){
            if(tmpState){
                OnTriggerPressed(tmpState);
            }
            wasPressed = !wasPressed;
        }
    }

    public void Shoot(){
        Rigidbody ball = CreateBall();
        Launch(ball);
    }

    private void Launch(Rigidbody ball){
        ball.AddForce(transform.forward * 1000f);
    }

    private Rigidbody CreateBall(){
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = transform.position;
        ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        Rigidbody ballRigidbody = ball.AddComponent<Rigidbody>();
        ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        return ballRigidbody;
    }

    public void OnTriggerPressed(bool isPressed){
        if(isPressed){
            Shoot();
        }
    }
}
