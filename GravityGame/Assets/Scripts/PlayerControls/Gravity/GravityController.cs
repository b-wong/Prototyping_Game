using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class seems redundant cz we're doing the same thing in the character controller

public class GravityController : MonoBehaviour
{
    public static PlayerController player1;
    public static PlayerController player2;

    PhysicsController physicsController;

    private void Start()
    {
        physicsController = GetComponent<PhysicsController>();
    }

    enum Gravity
    {
        up,
        down
    }

    Gravity cur_Gravity;

    public static float GravityForce1 = 9.8f;
    public static float GravityForce2 = 9.8f;

    //private void FixedUpdate()
    //{
    //    GravityInput();
    //    ApplyGravity();
    //}
   
    public void GravityInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GravityForce1 = -GravityForce1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GravityForce2 = -GravityForce2;
        }
    }

    public void ApplyGravity()
    {

           player1.m_rigidbody.AddForce(new Vector3(0, GravityForce1, 0), ForceMode.Acceleration);
            player2.m_rigidbody.AddForce(new Vector3(0, GravityForce2, 0), ForceMode.Acceleration);
    }
}
