using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTheScenes : MonoBehaviour
{
    // Functions' buttons

    // To change the scene
    public void ChangeScene(int sceneIDX)
    {
        SceneManager.LoadScene(sceneIDX);
    }

    // To restart the level

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
