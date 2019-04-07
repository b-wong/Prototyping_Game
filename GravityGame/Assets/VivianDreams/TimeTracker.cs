using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    // found save at Users/ (user) / AppData / LocalLow / DefaultCompany / External Data P01 / savedata.json

    public float timeRecordedEveryNumberSeconds;
    private float m_timestampOfSinceLevelLoad = -1;

    [SerializeField]
    private TimerData m_data = new TimerData();

    // Start is called before the first frame update
    void Start()
    {
        timeRecordedEveryNumberSeconds = 2f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // need to call this somehow
    public void OnSceneClose()
    {
        if (m_timestampOfSinceLevelLoad == -1)
        {
            m_timestampOfSinceLevelLoad = Time.timeSinceLevelLoad;
            StartCoroutine(SaveDataOnInterval());
        }
        else
        {
            float timestamp = Time.timeSinceLevelLoad;
        }
    }

    //////// This is from script called LoadNextLevel:
    ////////public int levelToLoad;

    ////////public ExitTrigger[] exitTrigger;

    ////////private void Update()
    ////////{
    ////////    if (checkIfExitsOccupied())
    ////////        SceneManager.LoadScene(levelToLoad);
    ////////}

    ////////bool checkIfExitsOccupied()
    ////////{
    ////////    foreach (ExitTrigger exits in exitTrigger)
    ////////    {
    ////////        if (!exits.isTriggerActive)
    ////////            return false;
    ////////    }
    ////////    return true;
    ////////}

    public void SaveDataToFile()
    {
        string json = JsonUtility.ToJson(m_data, true);

        string path = Path.Combine(Application.persistentDataPath, "savedata.json");
        // Might not work on all operating systems!
        //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "savedata.json");

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write(json);
        }
    }


    private IEnumerator SaveDataOnInterval()
    {
        while (true)
        {
            float timestamp = Time.timeSinceLevelLoad;
            yield return new WaitForSecondsRealtime(3);
            //float timeWindow = Time.timeSinceLevelLoad - timestamp;

            //float clicksPerSecond = m_numberOfClicks / timeWindow;
            //float totalTimeBetweenClicks = 0;
            //for (int clickIndex = 0; clickIndex < m_timeBetweenClicks.Count; ++clickIndex)
            //{
            //    totalTimeBetweenClicks += m_timeBetweenClicks[clickIndex];
            //}
            //float averageTimeBetweenClicks = totalTimeBetweenClicks / m_timeBetweenClicks.Count;

            //m_data.AddData(clicksPerSecond, averageTimeBetweenClicks);

            m_data.AddData(timestamp);

            //m_numberOfClicks = 0;
            //m_timeBetweenClicks.Clear();
        }
    }

}
