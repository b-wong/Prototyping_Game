using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatePlayerCtrl : MonoBehaviour
{
    // a really scruffy script but I just needed to see if the collectable script would actually work with a different character controller script.

    float speed = 5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))    //jump         {             transform.Translate(Vector3.up * speed * Time.deltaTime);         }         if (Input.GetKey(KeyCode.A))    //left         {             transform.Translate(Vector3.left * speed * Time.deltaTime);         }         if (Input.GetKey(KeyCode.D))    // right         {             transform.Translate(Vector3.right * speed * Time.deltaTime);         }
    }
}
