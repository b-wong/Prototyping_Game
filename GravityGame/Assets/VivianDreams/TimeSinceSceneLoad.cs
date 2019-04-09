using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeSinceSceneLoad : MonoBehaviour
{
    public Button m_MyButton;
    public Text m_MyText;

    void Awake()
    {
        //Don't destroy the GameObject when loading a new Scene
        DontDestroyOnLoad(gameObject);
        // or DontDestroyOnLoad(this); ?

        //Make sure the Canvas isn't deleted so the UI stays on the Scene load
        DontDestroyOnLoad(GameObject.Find("Canvas"));

        if (m_MyButton != null)
            //Add a listener to call the LoadSceneButton function when the Button is clicked
            m_MyButton.onClick.AddListener(LoadSceneButton);
    }

    void Update()
    {      
        //Debug.Log("Time.timeSinceLevelLoad" + Time.timeSinceLevelLoad);
        //Output the time since the level loaded to the screen using this label
        m_MyText.text = "Time Since Loaded : " + Time.timeSinceLevelLoad;
    }

    void LoadSceneButton()
    {
        //Press this Button to load another Scene
        //Load the Scene named "Scene2"
        SceneManager.LoadScene("Scn_Cathr2");
    }
}
