using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTPItem : MonoBehaviour
{
     //Necessary to receive the event of the button
    private ButtonBehavior buttonBehavior;
    public GameObject tpItem;

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
        // set active the teleportation item
        tpItem.SetActive(true);
    }
}
