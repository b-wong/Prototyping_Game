using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// found save at Users/ (user) / AppData / LocalLow / DefaultCompany / External Data P01 / savedata.json
public class TimeTracker : MonoBehaviour
{    
    // What the file will be called when it saves:
    string filename = "data.json";
    // Variable for the path to the above file
    string pathToSaveFile;

    Scene sceneName;

    public float timeRecordedEveryNumberSeconds;
    private List<float> m_timeLevelTook = new List<float>();
   // private List<float> m_timeBetweenClicks = new List<float>();
    private float m_timestampOfSinceLevelLoad = -1;
    // private float m_timestampOfLastClick = -1;

    private float test = 1000;

    // access to the script TimerData
    [SerializeField]
    private TimerData gameData = new TimerData();

    private void Start()
    {
        pathToSaveFile = Application.persistentDataPath + "/" + filename;
        //Debug.Log(Application.persistentDataPath);
        //Debug.Log(pathToSaveFile);
        //timeRecordedEveryNumberSeconds = 2f;
    }

    private void Update()
    {
        // get scene name
        sceneName = SceneManager.GetActiveScene();

        //following GameProgrammingAcademy youtube tutorial
        // to save data to json file, hit V
        if (Input.GetKeyDown(KeyCode.V))
        {          
           // gameData.sceneLength = Time.timeSinceLevelLoad;

            gameData.date = System.DateTime.Now.ToShortDateString();
            gameData.time = System.DateTime.Now.ToShortTimeString();
            SaveData();
        }

        // to see what is in Json file hit B
        if (Input.GetKeyDown(KeyCode.B))
        {
            ReadData();
        }
    }

    // Add a call to LoadNextLevel Script
    public void OnSceneClose()
    {
        if (m_timestampOfSinceLevelLoad == -1)
        {
            m_timestampOfSinceLevelLoad = Time.timeSinceLevelLoad;
            StartCoroutine(SaveDataIEnumerator());
        }
        else
        {
            float timestamp = Time.timeSinceLevelLoad;
            m_timeLevelTook.Add(timestamp);            
            //m_timeBetweenClicks.Add(timestamp - m_timestampOfLastClick);
        }

        Debug.Log("Got into OnSceneClose");
        gameData.sceneLength = sceneName + ": " + Time.timeSinceLevelLoad;
    }

    public void SaveData()
    {
        //string path = Path.Combine(Application.persistentDataPath, "savedata.json");
        gameData.sceneLength = sceneName + ": " + Time.timeSinceLevelLoad;

        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(pathToSaveFile, contents);

        //string json = JsonUtility.ToJson(m_data, true);
        //string path = Path.Combine(Application.persistentDataPath, "savedata.json");

        using (StreamWriter writer = new StreamWriter(pathToSaveFile))
        {
            writer.Write(contents);
        }
    }

    public void ReadData()
    {
        // in case file tampered with or corrupted, use try and catch
        try
        {
            // check if file exists so don't get an error if was deleted
            if (System.IO.File.Exists(pathToSaveFile))
            {
                string contents = System.IO.File.ReadAllText(pathToSaveFile);
                gameData = JsonUtility.FromJson<TimerData>(contents);
                Debug.Log(gameData.date + ", " + gameData.time + ", " + gameData.sceneLength);
            }
            else
            {
                Debug.Log("Unable to read the save data, file does not exist");
                gameData = new TimerData();
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private IEnumerator SaveDataIEnumerator()
    {
        while (true)
        {
            float timestamp = Time.timeSinceLevelLoad;
            yield return new WaitForSecondsRealtime(1);

            //gameData.AddData(m_timeLevelTook);

            gameData.AddData(timestamp);

            m_timeLevelTook.Clear();
        }


    }


    //private IEnumerator SaveDataOnInterval()
    //{
    //    while (true)
    //    {
    //        float timestamp = Time.timeSinceLevelLoad;
    //        yield return new WaitForSecondsRealtime(3);

    //        gameData.AddData(timestamp);



            ////float timeWindow = Time.timeSinceLevelLoad - timestamp;

            ////float clicksPerSecond = m_numberOfClicks / timeWindow;
            ////float totalTimeBetweenClicks = 0;
            ////for (int clickIndex = 0; clickIndex < m_timeBetweenClicks.Count; ++clickIndex)
            ////{
            ////    totalTimeBetweenClicks += m_timeBetweenClicks[clickIndex];
            ////}
            ////float averageTimeBetweenClicks = totalTimeBetweenClicks / m_timeBetweenClicks.Count;

            ////m_data.AddData(clicksPerSecond, averageTimeBetweenClicks);



            ////m_numberOfClicks = 0;
            ////m_timeBetweenClicks.Clear();
        //}
    //}
}






//public void OnSceneClose()
//{
//    if (m_timestampOfSinceLevelLoad == -1)
//    {
//        m_timestampOfSinceLevelLoad = Time.timeSinceLevelLoad;
//        StartCoroutine(SaveDataOnInterval());
//    }
//    else
//    {
//        float timestamp = Time.timeSinceLevelLoad;
//    }
//}



////////// This is from script called LoadNextLevel:
//////////public int levelToLoad;

//////////public ExitTrigger[] exitTrigger;

//////////private void Update()
//////////{
//////////    if (checkIfExitsOccupied())
//////////        SceneManager.LoadScene(levelToLoad);
//////////}

//////////bool checkIfExitsOccupied()
//////////{
//////////    foreach (ExitTrigger exits in exitTrigger)
//////////    {
//////////        if (!exits.isTriggerActive)
//////////            return false;
//////////    }
//////////    return true;
//////////}
