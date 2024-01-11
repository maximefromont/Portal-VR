using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{

    private bool OnDebug;    
    // Start is called before the first frame update
    void Start()
    {
        OnDebug = Convert.ToBoolean(PlayerPrefs.GetInt("DebugMode"));
        OnDebug = true;
        gameObject.SetActive(OnDebug);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
