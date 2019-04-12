using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Singleton pattern
    public static AudioManager amInstance = null;
    private void Awake()
    {
        if (amInstance == null)
        {
            amInstance = this;
        }
        else if (amInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
