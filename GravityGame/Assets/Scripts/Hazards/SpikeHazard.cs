using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHazard : MonoBehaviour
{
    public delegate void DeathAction();
    public static event DeathAction onDeath;


    public GameObject player1;
    public GameObject player2;
    public Transform player1RespawnPoint;
    public Transform player2RespawnPoint;

    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            player1.GetComponentInChildren<GrabObject>().OnDeath();
            player1.transform.position = player1RespawnPoint.transform.position;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2.GetComponentInChildren<GrabObject>().OnDeath();
            player2.transform.position = player2RespawnPoint.transform.position;
        }
    }
}