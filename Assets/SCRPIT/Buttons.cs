using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class Buttons : MonoBehaviour
{

    public TextMeshProUGUI usernametext;
    private void Start()
    {
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        usernamePanel.SetActive(false);
    }
    
    // Cambio escena al 1r nivel + username

    public void GoToScene(int sceneIDX)
    {
        DataPersistence.sharedInstance.username = usernametext.text;
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

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

    public GameObject usernamePanel;
    public void UsernamePanel()
    {
        usernamePanel.SetActive(true);
    }



}
