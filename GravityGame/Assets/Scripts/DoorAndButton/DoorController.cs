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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        doorIsOpening = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        doorIsClosing = true;
    }





    

    //public GameObject Door;
    //public bool doorIsOpening;
    //public bool doorIsClosing;
    //public float doorMaxHeight;
    //public float doorMinHeight;

    //// Update is called once per frame
    //void Update()
    //{
    //    if (doorIsOpening)
    //    {
    //        Door.transform.Translate(Vector3.up * Time.deltaTime * 5);

    //        if (Door.transform.position.y > doorMaxHeight)
    //        {
    //            // if door is higher than this point, want door to stop going up
    //            doorIsOpening = false;
    //        }
    //    }

    //    if (doorIsClosing == true)
    //    {
    //        Door.transform.Translate(-Vector3.up * Time.deltaTime * 5);
    //        if (Door.transform.position.y < doorMinHeight)
    //        {
    //            // if door is higher than this point, want door to stop going up
    //            doorIsClosing = false;
    //        }

    //    }

    //    if (doorIsClosing == true && doorIsOpening == true)
    //    {
    //        doorIsClosing = true;
    //        doorIsOpening = false;
    //    }

    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    doorIsOpening = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    doorIsClosing = true;
    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other != null)
    //    {
    //        doorIsOpening = true;
    //        doorIsClosing = false;
    //    }
    //    else
    //    {
    //        doorIsOpening = false;
    //        doorIsClosing = true;

    //    }
    //}

    ////private void OnTriggerEnter2D(Collider2D collision)
    ////{
    ////    if (collision.gameObject.tag == "Player")
    ////    {
    ////        doorIsOpening = true;
    ////    }
    ////}

    ////private void OnTriggerExit2D(Collider2D collision)
    ////{
    ////    if (collision.gameObject.tag == "Player")
    ////    {
    ////        doorIsClosing = true;
    ////    }
    ////}

}
