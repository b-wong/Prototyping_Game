using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                IToggleable toggleable = hitInfo.collider.GetComponent<IToggleable>();
                toggleable?.Toggle();
            }
        }
    }
}
