using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PauseManager
{
    public static bool isPaused {get; private set;} = false;
    public static void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public static void UnPause()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public static void SetPause(bool isPaused)
    {
        if(isPaused) Pause();
        else UnPause();
    }
}
