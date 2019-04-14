using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwapper : MonoBehaviour
{
    public bool player1SwapPos;
    public bool player2SwapPos;

    Vector3 player1Position;
    Vector3 player2Position;
    
    GameObject player1Object;
    GameObject player2Object;
    
    GameObject RedSwapIndicator;
    GameObject PurpleSwapIndicator;

    bool canSwap = true;

    private void Awake()
    {
        player1Object = GameObject.FindWithTag("Player1");
        player2Object = GameObject.FindWithTag("Player2");

        RedSwapIndicator = GameObject.FindWithTag("RedPosSwapIndicator");
        PurpleSwapIndicator = GameObject.FindWithTag("PurplePosSwapIndicator");
    }

    private void Update()
    {
        if (player1SwapPos && player2SwapPos)
        {
            positionSwap();
        }

        positionSwapIndicator();
    }

    void positionSwapIndicator()
    {
        if (player1SwapPos)
            RedSwapIndicator.SetActive(true);
        else
            RedSwapIndicator.SetActive(false);


        if (player2SwapPos)
            PurpleSwapIndicator.SetActive(true);
        else
            PurpleSwapIndicator.SetActive(false);
    }

    void positionSwap()
    {
        bool player1GravityStatus = player1Object.GetComponent<PlayerPlatformingController>().gravitySwapped;
        bool player2GravityStatus = player2Object.GetComponent<PlayerPlatformingController>().gravitySwapped;

        player1Position = player1Object.transform.position;
        player2Position = player2Object.transform.position;

        player1Object.GetComponent<PlayerPlatformingController>().gravitySwapped = player2GravityStatus;
        player2Object.GetComponent<PlayerPlatformingController>().gravitySwapped = player1GravityStatus;

        player1Object.transform.position = player2Position;
        player2Object.transform.position = player1Position;

        player1SwapPos = false;
        player2SwapPos = false;
    }
}
