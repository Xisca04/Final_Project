using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTheScenes : MonoBehaviour
{
    public void ChangeScene(int sceneIDX)
    {
        SceneManager.LoadScene(sceneIDX);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
