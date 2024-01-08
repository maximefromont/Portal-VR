using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Input : MonoBehaviour
{

    [SerializeField]
    private GameObject _TriggerCube;
    [SerializeField]
    private GameObject _BackButtonCube;
    [SerializeField]
    private GameObject _TouchPadCube;
    [SerializeField]
    private InputManager _inputManager;

    private void Awake() => _inputManager = InputManager.Instance;

    private void Update()
    {
        _TriggerCube.SetActive(_inputManager.IsTrigger);
        _BackButtonCube.SetActive(_inputManager.IsBackButton);

        var renderer = _TouchPadCube.GetComponent<Renderer>();
        var val = _inputManager.TouchPad;
        // Create a color from Vector2
        renderer.material.color = new Color(val.x, val.y, 0);
    }
}
