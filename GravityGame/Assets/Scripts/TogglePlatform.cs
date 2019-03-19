using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    private LayerMask platformLayer;

    public Player_ManipController manipulatorController;


    private void Awake()
    {
        platformLayer = LayerMask.GetMask("TogglePlatform");
        manipulatorController = GetComponent<Player_ManipController>();
    }

    // Update is called once per frame
    void Update()
    {
        platformToggler();
    }

    //toggles the platform;
    void platformToggler()
    {   
        if (Input.GetMouseButtonDown(0))
        {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, platformLayer))
            {
                if (hit.transform.name == "plat_Cube")
                {
                    if (manipulatorController.ActivatePlatformCharges > 0)
                    {
                        manipulatorController.ActivatePlatformCharges--;
                        hit.transform.gameObject.SetActive(false);
                    }
                }

                
                if (hit.transform.name == "plat_ToggleIndicator")
                {
                    if (manipulatorController.ActivatePlatformCharges > 0)
                    {
                        manipulatorController.ActivatePlatformCharges--;
                        hit.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
