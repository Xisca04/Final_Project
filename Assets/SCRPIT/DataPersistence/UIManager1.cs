using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager1 : MonoBehaviour
{
    // UIManager 1 -- Saves the username information

    public TMP_InputField inputField;

    private string existingUsername;
    private const string USERNAME = "USERNAME"; 

    private void Start()
    {
        existingUsername = PlayerPrefs.GetString(USERNAME); 

        if (existingUsername != "")
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = existingUsername; 
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveUsername();
        }
    }

    public void SaveUsername()
    {
        string inputText = inputField.text;
       

        if (inputText == "")
        {
            DataPersistence.sharedInstance.username = inputField.placeholder.GetComponent<TextMeshProUGUI>().text;
            Debug.Log($"Estoy guardando playHolder {inputField.placeholder.GetComponent<TextMeshProUGUI>().text}");
        }
        else
        {
            DataPersistence.sharedInstance.username = inputText;
            Debug.Log($"Estoy guardando");
        }
    }

   

   public void SaveUsernameWithPlayerPrefs()
   {
       PlayerPrefs.SetString("USERNAME", DataPersistence.sharedInstance.username);
   }
}
