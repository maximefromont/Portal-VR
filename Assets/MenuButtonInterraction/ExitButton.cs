using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ExitButton.cs: Start()");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On click, exit the game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitButton.cs: ExitGame()");
    }
}
