using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int levelToLoad;

    public ExitTrigger[] exitTrigger;

    private void Update()
    {
        if (checkIfExitsOccupied())
            SceneManager.LoadScene(levelToLoad);
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