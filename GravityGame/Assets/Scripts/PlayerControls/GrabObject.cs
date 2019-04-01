using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectHolding;

    private float timeOfPickup, timeOfDrop;

    private void Update()
    {
        //drops pick up if holding carryable
        if (Input.GetButtonDown("Player2Grab") && objectHolding != null && timeOfPickup + 0.1f < Time.time)
        {
            dropCarryable();
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);

        //picks up a carryable if not holding anything
        if (Input.GetButtonDown("Player2Grab") && objectHolding == null && collision.tag == "Carryable" && timeOfDrop + 0.2f < Time.time)
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

}
