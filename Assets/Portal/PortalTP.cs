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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
    }

    void OnCollisionEnter(Collision collision)
    {
        // Add a variable in collision.gameobject fromPortal = true if not already exist
        FromPortal fromPortal = collision.gameObject.GetComponent<FromPortal>();
        if (fromPortal == null || !fromPortal.fromPortal)
        {
            collision.gameObject.AddComponent<FromPortal>();
            collision.gameObject.transform.position = portalLinked.transform.position;
        }      
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
