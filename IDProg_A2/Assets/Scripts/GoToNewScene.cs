using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour {

    private float timer;
    private bool startTimer;
    private string sceneName;
    private int sceneIndex;


    private void Start()
    {
        timer = 0.0f;
        startTimer = false;
        sceneIndex = -1;
        sceneName = "";
    }


    private void Update()
    {
        // if timer has not started, don't update
        if (!startTimer)
            return;

        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            // Check which method of Changing Scene
            // we using
            if (sceneName != "")
                GoToNewScene_STRING(sceneName);
            else if (sceneIndex != -1)
                GoToNewScene_INT(sceneIndex);
            // stop timer
            startTimer = false;
        }

    }



    // Load new Scene based on Index Passed In
    // index found from build settings
    public void GoToNewScene_INT(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Load new Scene based on String Passed In
    // name found from scene Name
    public void GoToNewScene_STRING(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Load new Scene based on String Passed In
    // name found from scene Name
    // only AFTER the timer expires
    public void GoToNewScene_STRING_Timer(string _sceneName, float _timer)
    {
        // Check if a timer is already running
        if (startTimer)
            return;

        // Assign the Data
        sceneName = _sceneName;
        timer = _timer;
        startTimer = true;
    }

    public void GoToNewScene_INT_Timer(int _sceneIndex, float _timer)
    {
        // Check if a timer is already running
        if (startTimer)
            return;

        // Assign the Data
        sceneIndex = _sceneIndex;
        timer = _timer;
        startTimer = true;
    }

}
