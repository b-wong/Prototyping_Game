﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [FMODUnity.EventRef]
    string collectableSound;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2"){
        
            //PlayerPlatformingController.numCollectable = PlayerPlatformingController.numCollectable + 1;
            GameManager.instance.gravitySwapCharges = GameManager.instance.gravitySwapCharges + 1;
            //FMODUnity.RuntimeManager.PlayOneShot(collectableSound);
            Destroy(gameObject);
        }
    }
}
