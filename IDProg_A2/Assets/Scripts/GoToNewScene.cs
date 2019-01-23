using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour {

    // Load new Scene based on Index Passed In
    // index found from build settings
    public void GoToNewScene_INT(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Load new Scene based on Index Passed In
    // name found from scene Name
    public void GoToNewScene_STRING(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
