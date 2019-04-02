using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryableObjectSpawner : MonoBehaviour
{
    Vector3 originalPos;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    //testing respawn function
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        RespawnObject();
    //    }
    //}

    public void RespawnObject()
    {
        transform.position = originalPos;
    }
}
