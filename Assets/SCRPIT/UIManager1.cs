using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager1 : MonoBehaviour
{
    public TMP_InputField inputField;

    private void Start()
    {
        existingUsername = PlayerPrefs.GetString(USERNAME); // Busca si existe la clave username

        if (existingUsername != "")
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = existingUsername; // Si se ha guardado un username en player prefs, se sobrescribe
        }
    }

    public void SaveUsername()
    {
        string inputText = inputField.text;

        if (inputText == "")
        {
            DataPersistence.sharedInstance.username = inputField.placeholder.GetComponent<TextMeshProUGUI>().text;
        }
        else
        {
            DataPersistence.sharedInstance.username = inputText;
        }
    }

   

   public void SaveUsernameWithPlayerPrefs()
   {
       PlayerPrefs.SetString("USERNAME", DataPersistence.sharedInstance.username);
   }

   private string existingUsername;
   private const string USERNAME = "USERNAME"; // tipo CONS no se puede modificar, es una constante
   
}
