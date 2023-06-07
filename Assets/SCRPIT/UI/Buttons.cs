using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class Buttons : MonoBehaviour
{
    // Functions' buttons

    public TextMeshProUGUI usernametext;
    public GameObject instructionsPanel;
    public GameObject optionsPanel;
    public GameObject usernamePanel;

    private void Start()
    {
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        usernamePanel.SetActive(false);
    }
    
    // Change the scene 

    public void GoToScene(int sceneIDX)
    {
        SceneManager.LoadScene(sceneIDX);
        Time.timeScale = 1.0f;
    }

    // Active instructions panel

    public void InstructionsOn()
    {
        instructionsPanel.SetActive(true);
    }

    // Return to back menu

    public void ReturnMain()
    {
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    // Active options panel

    public void OptionsOn()
    {
        optionsPanel.SetActive(true);
    }

    // Exit the game

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

    // Active username panel

    public void UsernamePanel()
    {
        usernamePanel.SetActive(true);
    }



}
