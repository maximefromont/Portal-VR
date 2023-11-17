using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromPortal : MonoBehaviour
{
    public bool fromPortal = true;
}

public class PortalTP : MonoBehaviour
{
    public GameObject portalLinked;
    private AudioSource audioSource;
    private Vector3 portalOut;
    private Vector3 oldVelocity;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        string portalName = gameObject.name;
        Debug.Log("Hello from " + portalName +", I am linked to " + portalLinked.name);
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        // get portal position
        Vector3 portalPosition = transform.position;
        // Get x rotation of portal
        float xPortalRotation = transform.rotation.eulerAngles.x;
        float yPortalRotation = transform.rotation.eulerAngles.y;
        // portal out is vector to player position
        portalOut = playerPosition - portalPosition;
        // normalize
        portalOut = portalOut.normalized;
        portalOut = new Vector3(-portalOut.x*(float)Math.Sin(yPortalRotation), -(float)Math.Sin(xPortalRotation)*4, portalOut.z*(float)Math.Cos(yPortalRotation));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (portalLinked == null)
        {
            return;
        }
        
        // Add a variable in collision.gameobject fromPortal = true if not already exist
        FromPortal fromPortal = collision.gameObject.GetComponent<FromPortal>();
        if (fromPortal == null)
        {
            //audioSource.Play();
            // wait for the sound to finish
            //StartCoroutine(WaitForSound());
            collision.gameObject.AddComponent<FromPortal>();
            collision.gameObject.transform.position = portalLinked.transform.position;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            oldVelocity = rb.velocity;
            rb.velocity = Vector3.zero;
        }
        else{
            // change force of collision gameobject
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.Scale(oldVelocity, portalOut);
        }
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
    }

    void OnCollisionExit(Collision collision){
        // Remove the variable in collision.gameobject fromPortal = false
        FromPortal fromPortal = collision.gameObject.GetComponent<FromPortal>();
        Destroy(fromPortal);
    }

    void Update()
    {
        //When any object touch the portal, it will be teleported to the linked portal

    }
}
