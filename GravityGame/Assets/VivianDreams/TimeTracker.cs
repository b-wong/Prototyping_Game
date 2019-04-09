using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    // found save at Users/ (user) / AppData / LocalLow / DefaultCompany / External Data P01 / savedata.json

    //following GameProgrammingAcademy youtube tutorial
    // what the file will be called when it saves:
    string filename = "data.json";
    // variable for the path to the above file
    string pathToSaveFileTest;


    public float timeRecordedEveryNumberSeconds;
    private float m_timestampOfSinceLevelLoad = -1;

    // access to the script TimerData
    private TimerData gameData = new TimerData();

    private void Start()
    {
        pathToSaveFileTest = Application.persistentDataPath + "/" + filename;
        Debug.Log(Application.persistentDataPath);
        Debug.Log(pathToSaveFileTest);


        timeRecordedEveryNumberSeconds = 2f;

    }

    private void Update()
    {
        //following GameProgrammingAcademy youtube tutorial
        // to save data to json file, hit V
        if (Input.GetKeyDown(KeyCode.V))
        {          
            gameData.sceneLength = Time.timeSinceLevelLoad;

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

    void SaveData()
    {
        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(pathToSaveFileTest, contents);
    }

    //    public void SaveDataToFile()
    //    {    
    //        string path = Path.Combine(Application.persistentDataPath, "savedata.json");
    //        
    //        using (StreamWriter writer = new StreamWriter(path))
    //        {
    //            writer.Write(jsonContents);
    //        }
    //    }


    void ReadData()
    {
        // in case file tampered with or corrupted, use try and catch
        try
        {
            // check if file exists so don't get an error if was deleted
            if (System.IO.File.Exists(pathToSaveFileTest))
            {

                string contents = System.IO.File.ReadAllText(pathToSaveFileTest);
                gameData = JsonUtility.FromJson<TimerData>(contents);
                Debug.Log(gameData.date + ", " + gameData.time);
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
