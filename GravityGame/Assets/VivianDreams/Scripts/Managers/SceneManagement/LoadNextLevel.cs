using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int levelToLoad;

    public ExitTrigger[] exitTrigger;

    //trying make JSON save work
    public TimeTracker timeTrackerScript;

    private void Update()
    {
        if (checkIfExitsOccupied())
        {
            //trying make JSON save work
            //timeTrackerScript.OnSceneClose();

            GameManager.instance.LoadNextScene();
        }
        //{
            //Debug.Log("got in LoadNextLevel script's checkIfExitsOccupied");        
            //SceneManager.LoadScene(levelToLoad);
        //}
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