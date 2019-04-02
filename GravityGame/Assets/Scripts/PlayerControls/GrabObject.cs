using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    enum Player { Player1, Player2 };
    [SerializeField]
    private Player currentPlayer;

    //Grab Input
    string GrabButton;


    [SerializeField]
    private GameObject objectHolding;

    //time of pickup and dropping item
    private float timeOfPickup, timeOfDrop;
    

    private void Start()
    {
        if (currentPlayer == Player.Player1)
            GrabButton = "Player1Grab";
        else GrabButton = "Player2Grab";
    }


    private void Update()
    {
        //drops pick up if holding carryable
        if (Input.GetButtonDown(GrabButton) && objectHolding != null && timeOfPickup + 0.1f < Time.time)
        {
            dropCarryable();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //picks up a carryable if not holding anything
        if (Input.GetButtonDown(GrabButton) && objectHolding == null && collision.tag == "Carryable" && timeOfDrop + 0.2f < Time.time)
        {
            pickUpCarryable(collision);
        }
    }


    void pickUpCarryable(Collider2D collision)
    {
        collision.attachedRigidbody.simulated = false;
        objectHolding = collision.gameObject;
        collision.transform.parent = this.transform;
        collision.transform.localPosition = transform.localPosition;

        timeOfPickup = Time.time;
    }

    void dropCarryable()
    {
        objectHolding.GetComponent<Rigidbody2D>().simulated = true;
        objectHolding.transform.parent = null;
        objectHolding = null;

        timeOfDrop = Time.time;
    }

    public void OnDeath()
    {
        if (objectHolding != null)
        {
            objectHolding.GetComponent<CarryableObjectSpawner>().RespawnObject();
            objectHolding.GetComponent<Rigidbody2D>().simulated = true;
            objectHolding.transform.parent = null;
            objectHolding = null;
        }
    }

}
