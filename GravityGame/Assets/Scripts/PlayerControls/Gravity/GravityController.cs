using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;

    enum Gravity
    {
        up,
        down
    }

    Gravity cur_Gravity;

    public float GravityForce1 = 9.8f;
    public float GravityForce2 = 9.8f;

    private void FixedUpdate()
    {
        GravityInput();
        ApplyGravity();
    }

    private void GravityInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            GravityForce1 = -GravityForce1;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            GravityForce2 = -GravityForce2;
    }

    void ApplyGravity()
    {
        player1.m_rigidbody.AddForce(new Vector3(0, GravityForce1, 0), ForceMode.Acceleration);
        player2.m_rigidbody.AddForce(new Vector3(0, GravityForce2, 0), ForceMode.Acceleration);
    }
}
