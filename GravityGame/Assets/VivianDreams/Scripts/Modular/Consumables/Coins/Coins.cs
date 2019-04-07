using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static int numCoin = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2") {
            //numCoin = numCoin + 1;
            GameManager.instance.scoreFromScene = GameManager.instance.scoreFromScene + 1;
            Destroy(gameObject); 
        }
    }
}
