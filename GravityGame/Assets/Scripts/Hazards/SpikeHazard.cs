using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHazard : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public Transform player1RespawnPoint;
    public Transform player2RespawnPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            player1.transform.position = player1RespawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2.transform.position = player2RespawnPoint.transform.position;
        }
    }
}