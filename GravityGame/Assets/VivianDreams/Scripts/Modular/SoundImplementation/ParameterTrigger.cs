using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterTrigger : MonoBehaviour
{

    public int parameterValue;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.amInstance.mainTheme.setParameterValue("AddTrack", parameterValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.amInstance.mainTheme.setParameterValue("AddTrack",parameterValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
