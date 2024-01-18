using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorUp : MonoBehaviour
{
    private ButtonBehavior buttonBehavior;
    public GameObject Door;

    void Start()
    {
        //Necessary to recieve button press event
        buttonBehavior = GetComponent<ButtonBehavior>();
        buttonBehavior.OnButtonPress += HandleButtonPress;
    }

    void Update()
    {
        
    }

    IEnumerator OpenDoor(float seconds, GameObject Door)
    {
        while (Door.transform.position.y < 3)
        {
            Door.transform.position += new Vector3(0, 0.001f, 0);
            Debug.Log("Door position: " + Door.transform.position);
            yield return new WaitForSeconds(seconds);
        }
    }

    private void HandleButtonPress()
    {
        StartCoroutine(OpenDoor(0.001f, Door));
    }
}
