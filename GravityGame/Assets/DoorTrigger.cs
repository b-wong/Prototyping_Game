using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController[] DoorInfluences;


    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("enter");

        if (other != null)
        {
            foreach (DoorController door in DoorInfluences)
            {
                door.isOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("exit");
            foreach (DoorController door in DoorInfluences)
            {
                door.isOpen = false;
            }
        }
    }

}
