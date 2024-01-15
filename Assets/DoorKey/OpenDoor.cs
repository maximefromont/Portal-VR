using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public detectkeyObject detectKeyObject; 
   //make an a door move up after 10 seconds
    void Start()
    {
         
         detectKeyObject.onKeyTouch.AddListener(OnKeyTouch);
    }

    void OnKeyTouch()
    {
        Debug.Log("You have the key !!!!!");
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(1);
        transform.Translate(0, 5, 0);
    }

    
}
