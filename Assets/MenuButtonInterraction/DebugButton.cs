using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    private bool OnDebug;
    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on click, toggle debug mode
    public void ToggleDebug()
    {
        OnDebug = !OnDebug;
        OnDebug = Convert.ToBoolean(PlayerPrefs.GetInt("DebugMode"));
        PlayerPrefs.SetInt("DebugMode", Convert.ToInt32(OnDebug));
        gameObject.SetActive(OnDebug);
        if(OnDebug){
            //set color red
        }
        else{
            // set color green
        }
    }
}
