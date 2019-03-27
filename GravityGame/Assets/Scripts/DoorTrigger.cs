using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController[] DoorInfluences;
    
    private int numberOfInfluences;

    private void Update()
    {
        if (numberOfInfluences > 0)
            foreach (DoorController door in DoorInfluences)
                door.isOpen = true;

        else
            foreach (DoorController door in DoorInfluences)
                door.isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
            numberOfInfluences++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
            numberOfInfluences--;
    }

}
