using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// found save at Users/ (user) / AppData / LocalLow / DefaultCompany / External Data P01 / savedata.json
public class TimeTracker : MonoBehaviour
{
    // Variable for the path to the save file
    string pathToSaveFile;

    Scene sceneName;

    public float timeRecordedEveryNumberSeconds;
    private List<float> m_timeLevelTook = new List<float>();   
    private float m_timestampOfSinceLevelLoad = -1;  

    private float test = 1000;

    // access to the script TimerData
    [SerializeField]
    private TimerData gameData = new TimerData();

    private void Start()
    {
        pathToSaveFile = Application.persistentDataPath + "/" + SceneManager.GetActiveScene().name + ".json";  
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

    // Called from LoadNextLevel Script
    public void OnSceneClose()
    {
        if (m_timestampOfSinceLevelLoad == -1)
        {
            m_timestampOfSinceLevelLoad = Time.timeSinceLevelLoad;
            SaveData();        
        }
        else
        {
            float timestamp = Time.timeSinceLevelLoad;
            m_timeLevelTook.Add(timestamp);            
        }

        gameData.sceneLength = sceneName.name + ": " + Time.timeSinceLevelLoad;
    }

    public void SaveData()
    {       
        gameData.sceneLength = sceneName.name + ": " + Time.timeSinceLevelLoad;

        string contents = JsonUtility.ToJson(gameData, true);
       
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

}
