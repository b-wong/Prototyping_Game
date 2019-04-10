using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerData
{
    public string date = "";
    public string time = "";

    //public float sceneLength;
    public string sceneLength = "";

    [SerializeField]
    private List<float> m_timeSinceLevelLoad = new List<float>();

    public void AddData(float timeSinceLevelLoad)
    {
        m_timeSinceLevelLoad.Add(timeSinceLevelLoad);    
    }

}

//[SerializeField]
//private List<float> m_clicksPerSecond = new List<float>();
//[SerializeField]
//private List<float> m_timePerClick = new List<float>();

//public void AddData(float clicksPerSecond, float timePerClick)
//{
//    m_clicksPerSecond.Add(clicksPerSecond);
//    m_timePerClick.Add(timePerClick);
//}
