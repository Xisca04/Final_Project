using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void Start()
    {
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    
    // Cambio escena al 1r nivel
    public void GoToScene(int sceneIDX)
    {
        SceneManager.LoadScene(sceneIDX);
    }

    public GameObject instructionsPanel;

    public void InstructionsOn()
    {
        instructionsPanel.SetActive(true);
    }

    public void ReturnMain()
    {
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public GameObject optionsPanel;
    public void OptionsOn()
    {
        optionsPanel.SetActive(true);
    }

    
}
