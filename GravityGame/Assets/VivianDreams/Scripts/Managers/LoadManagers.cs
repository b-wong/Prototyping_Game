using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManagers : MonoBehaviour
{
    // A simple script to load all necessary managers for the game if any are missing.
    public GameObject gameManager;
    public GameObject audioManager;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (AudioManager.amInstance == null)
        {
            Instantiate(audioManager);
        }
    }

}
