﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjController : MonoBehaviour {

    Rigidbody2D rb2d;
    Vector3 objPos;

    Gravity gravity;

    private int numMouse;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        gravity = GetComponent<Gravity>();
    }

    // drag and drop
    public void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (pos);
    }

    void Update () {
        //this.gravity.GravityAdd();

    }
}
