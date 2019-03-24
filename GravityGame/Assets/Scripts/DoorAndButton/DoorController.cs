using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public GameObject Door;
    public bool doorIsOpening;
    public bool doorIsClosing;
    public float doorMaxHeight;
    public float doorMinHeight;

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening == true)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
            // 0.10044 = fully open in the test scene
            if (Door.transform.position.y > doorMaxHeight)
            {
                // if door is higher than this point, want door to stop going up
                doorIsOpening = false;
            }
        }

        if (doorIsClosing == true)
        {
            Door.transform.Translate(-Vector3.up * Time.deltaTime * 5);
            if (Door.transform.position.y < doorMinHeight)
            {
                // if door is higher than this point, want door to stop going up
                doorIsClosing = false;
            }

        }

        if (doorIsClosing == true && doorIsOpening == true)
        {
            doorIsClosing = true;
            doorIsOpening = false;
        }

    }

    //private void OnMouseDown()
    //{
    //    // click on button = door opens
    //    doorIsOpening = true; 
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        doorIsOpening = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        doorIsClosing = true;
    }

}
