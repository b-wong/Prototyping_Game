using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isActiveButton;
    
    public DoorController[] DoorInfluences;
    
    private int numberOfInfluences;

    private void Update()
    {
        if (numberOfInfluences > 0)
            foreach (DoorController door in DoorInfluences)
                isActiveButton = true;

        else
            foreach (DoorController door in DoorInfluences)
                isActiveButton = false;
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
