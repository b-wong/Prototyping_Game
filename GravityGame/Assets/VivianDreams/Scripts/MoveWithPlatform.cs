using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    GameObject playerHolder;


    private void Awake()
    {
        playerHolder = GameObject.FindWithTag("PlayerHolder");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.parent.SetParent(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.parent.SetParent(playerHolder.transform);
        }
    }

}
