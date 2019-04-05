using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    //script to reset current scene
	void Update ()
    {
        if (Input.GetButtonDown("ReloadScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
