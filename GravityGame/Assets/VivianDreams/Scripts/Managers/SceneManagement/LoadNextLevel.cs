using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int levelToLoad;

    public ExitTrigger[] exitTrigger;

    //to make JSON save work
    public TimeTracker timeTrackerScript;

    private void Update()
    {
        if (checkIfExitsOccupied())
        {
            //to make JSON save work
            timeTrackerScript.OnSceneClose();

            GameManager.instance.LoadNextScene();
        }

    }

    bool checkIfExitsOccupied()
    {
        foreach (ExitTrigger exits in exitTrigger)
        {
            if (!exits.isTriggerActive)
                return false;
        }
        return true;
    }
}