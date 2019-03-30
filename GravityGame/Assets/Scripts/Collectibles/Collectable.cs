using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2"){
        
            PlayerPlatformingController.numCollectable = PlayerPlatformingController.numCollectable + 1;

            Destroy(gameObject);
            //Debug.Log(characterController.numCollectable);
        }
    }
}
