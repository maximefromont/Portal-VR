using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private Renderer rend;

    private Color initial_color;
    private Vector3 initial_scale;
    private Vector3 initial_position;

    private Vector3 button_pressed_scale_vector;
    private Vector3 button_pressed_move_vector;

    public delegate void ButtonPressAction();
    public event ButtonPressAction OnButtonPress;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        initial_color = rend.material.color;
        initial_scale = rb.transform.localScale;
        initial_position = rb.transform.localPosition;

        button_pressed_scale_vector = new Vector3(1.0f, 0.5f, 1.0f);
        button_pressed_move_vector = new Vector3(0f, -0.01f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {
        OnButtonPress?.Invoke();

        //rb.transform.localScale = Vector3.Scale(initial_scale, button_pressed_scale_vector);
        rb.transform.localPosition = initial_position + button_pressed_move_vector;


        //Test cube spawning
        //GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //test.transform.position = rb.transform.localPosition + new Vector3(0.0f, 2.0f, 2.0f);
        //Rigidbody testRb = test.AddComponent<Rigidbody>();
    }

    public void UnpressButton()
    {
        //rb.transform.localScale = initial_scale;
        rb.transform.localPosition = initial_position;
    }
}
