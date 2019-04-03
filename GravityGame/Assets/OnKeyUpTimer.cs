using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyUpTimer : MonoBehaviour
{
    //public string jumpButton = "Player1Jump";
    //public string horizontalCtrl = "Player1Horizontal";
    //public string freezeButton = "Player1Freeze";
    //public string gravSwapButton = "Player1Grav";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("Player1Jump"))
        {
            Debug.Log("Space key was released");
        }




    }

    void StartTimer()
    {

    }

}
