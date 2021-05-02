using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //this script pauses the game while the debug menu is open
    [SerializeField] static bool isGamePaused = false; //this is to later check if the game is paused or not
    [SerializeField] GameObject debuggerUI; //find the debugger menu

    public void ButtonPressed() //this is attached to the debugger button and either pauses or resumes the game
    {
        if (isGamePaused == false)
        {
            Paused();
        }
        else
        {
            Resume();
        }
    }
    
    //these methods turn the debugger menu on or off, pause and resume the game, and change the isGamePaused variable
    void Resume()
    {
        debuggerUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Paused()
    {
        debuggerUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
