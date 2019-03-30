using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    [SerializeField] Text textUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = PlayerPlatformingController.numCollectable.ToString();
    }
}
