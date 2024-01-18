using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayVoiceLine : MonoBehaviour
{
    private ButtonBehavior buttonBehavior;
    public AudioSource audioSource;
    public string buttonName;
    private bool alredayPlayed;

    void Start()
    {
        //Necessary to recieve button press event
        buttonBehavior = GetComponent<ButtonBehavior>();
        buttonBehavior.OnButtonPress += HandleButtonPress;
        alredayPlayed = PlayerPrefs.GetInt(buttonName) == 1;
    }

        void Update()
    {
        
    }

        private void HandleButtonPress()
    {
        //TODO : Code behavior here
        if(!alredayPlayed){
            audioSource.Play();
            alredayPlayed = true;
            PlayerPrefs.SetInt(buttonName, 1);
        }
    }
}
