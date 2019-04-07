using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int scoreFromScene = 0;
    public int totalScore = 0;
    public int gravitySwapCharges = 0;

    // add score from scene to total score at end of scene. Reset scoreFromScene to 0 on scene reset or loading of next scene. String should show totalscore + scoreFromScene

    // Singleton pattern
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ExitApplication();
        ReloadCurrentScene();
    }

    void ExitApplication()
    {
        if (Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }

    // Reset the current level and gravity swap charges.
    void ReloadCurrentScene()
    {
        if (Input.GetButtonDown("ReloadScene"))
        {
            scoreFromScene = 0;
            gravitySwapCharges = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Loads the next scene in the build index.
    void LoadNextScene()
    {
        scoreFromScene = 0;
        totalScore = totalScore + scoreFromScene;
        gravitySwapCharges = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void AddScore()
    {

    }


}
