using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerData
{
    public string date = "";
    public string time = "";

    public string sceneLength = "";

    [SerializeField]
    private List<float> m_timeSinceLevelLoad = new List<float>();

    public void AddData(float timeSinceLevelLoad)
    {
        m_timeSinceLevelLoad.Add(timeSinceLevelLoad);    
    }

}
