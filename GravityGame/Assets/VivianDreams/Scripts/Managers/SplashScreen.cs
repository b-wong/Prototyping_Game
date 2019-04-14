using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Player1Jump") || Input.GetButtonDown("Player2Jump") || Input.GetButtonDown("1_jump_ctrl") || Input.GetButtonDown("2_jump_ctrl"))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetButtonDown("Player1Freeze") || Input.GetButtonDown("Player2Freeze") || Input.GetButtonDown("1_freeze_ctrl") || Input.GetButtonDown("2_freeze_ctrl"))
        {
            //credits
            SceneManager.LoadScene(16);
        }

        if (Input.GetButtonDown("Player1Grav") || Input.GetButtonDown("Player2Grav") || Input.GetButtonDown("1_grav_ctrl") || Input.GetButtonDown("2_grav_ctrl"))
        {
            //how to play
            SceneManager.LoadScene(15);
        }

        if (Input.GetButtonDown("Player1PositionSwap") || Input.GetButtonDown("Player2PositionSwap") || Input.GetButtonDown("1_positionSwap_ctrl") || Input.GetButtonDown("2_positionSwap_ctrl"))
        {
            //quit
            Debug.Log("quit");
            Application.Quit();
        }

    }
}