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


    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
    //    {
    //        SceneManager.LoadScene(levelToLoad);
    //    }
    //}
}

//[CustomEditor(typeof(LoadNextLevel))]
//public class LoadNextLevelEditor : Editor
//{
//    void OnInspectorGUI()
//    {
//        var loadNextLevel = target as LoadNextLevel;

        

//    }
//}