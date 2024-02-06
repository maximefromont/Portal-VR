using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public detectkeyObject detectKeyObject; 
    public GameObject Door;
   //make an a door move up after 10 seconds
    void Start()
    {
         
         detectKeyObject.onKeyTouch.AddListener(OnKeyTouch);
    }

    void OnKeyTouch()
    {
        Debug.Log("You have the key !!!!!");
        StartCoroutine(Open(0.00001f, Door));
    }

    IEnumerator Open(float seconds, GameObject Door)
    {
                AudioSource DoorSound = Door.GetComponent<AudioSource>();
        DoorSound.Play();
        while (Door.transform.position.y <30  )
        {
            Door.transform.position += new Vector3(0, 0.05f, 0);
            Debug.Log("Door position: " + Door.transform.position);
            yield return new WaitForSeconds(seconds);
        }
        DoorSound.Stop();



        
    }

    
}
