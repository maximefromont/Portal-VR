using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class Gift_select_script : XRSimpleInteractable
{
    //add audio source
    public AudioSource audioSource; 
    public string sceneName;

    protected override void  OnSelectEnter(XRBaseInteractor interactor)
    {
        // Run the audio source
        audioSource.Play();
        // Delete the object after 1.5 seconds
        Destroy(gameObject, 1.5f);       
    }


}

        

        
            


   

    




   
