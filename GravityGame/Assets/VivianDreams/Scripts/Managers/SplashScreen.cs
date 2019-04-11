using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Player1Jump") || Input.GetButtonDown("Player2Jump"))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetButtonDown("Player1Freeze") || Input.GetButtonDown("Player2Freeze"))
        {
            //credits
            SceneManager.LoadScene(16);
        }

        if (Input.GetButtonDown("Player1Grav") || Input.GetButtonDown("Player2Grav"))
        {
            //how to play
            SceneManager.LoadScene(15);
        }

        if (Input.GetButtonDown("Player1Grav") || Input.GetButtonDown("Player2Grav"))
        {
            //how to play
            SceneManager.LoadScene(15);
        }

        if (Input.GetButtonDown("Player1PositionSwap") || Input.GetButtonDown("Player2PositionSwap"))
        {
            //quit
            Debug.Log("quit");
            Application.Quit();
        }

    }
}