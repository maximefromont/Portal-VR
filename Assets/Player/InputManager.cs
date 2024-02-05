using System.Collections.Generic;

using Unity.Mathematics;

using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public bool IsTrigger { get; set; }
    public bool IsBackButton { get; set; }

    public bool IsPressButton  { get; set; }
    public bool IsAppButton  { get; set; }
    public bool IsTouchPad { get; set; }
    public float2 TouchPad { get; set; }

    private InputDevice _controller;
    private bool _isControllerConnected = false;
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        GetPicoDevice();
        GetPicoInputs();
    }

    private void GetPicoDevice()
    {
        List<InputDevice> leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count <= 0)
            _isControllerConnected = false;

        if (!_isControllerConnected && leftHandDevices.Count == 1)
        {
            _controller = leftHandDevices[0];
            _isControllerConnected = true;
        }
    }

    // Get the values from a Pico VR controller
    private void GetPicoInputs()
    {
        if (_isControllerConnected)
        {
            if (_controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue))
            {
                IsTrigger = triggerValue;
            }

            if (_controller.TryGetFeatureValue(CommonUsages.menuButton, out bool backButtonValue))
            {
                if(backButtonValue)
                {
                    Debug.Log("Back Button Pressed");
                    SceneManager.LoadScene("Menu");   
                }
            }

            if (_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 touchPadValue))
            {
                TouchPad = touchPadValue;
            }

            if (_controller.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool pressButtonValue))
            {
                IsPressButton = pressButtonValue;
            }
            if(_controller.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool touchPadValueTouched))
            {
                    
                IsTouchPad = touchPadValueTouched;
            }
        }
    }
}
