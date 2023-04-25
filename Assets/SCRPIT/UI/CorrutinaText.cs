using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CorrutinaText : MonoBehaviour
{
    // Corrutina texto - máquina escribir

    private string uiText = "Hola, qué tal?";
    public TextMeshProUGUI _uiText;

    private void Start()
    {
        StartCoroutine(WritingText());
    }

    private IEnumerator WritingText()
    {
        foreach(char character in uiText)
        {
            _uiText.text = _uiText.text + character;
            yield return new WaitForSeconds(0.3f);
        }
    }

    /*
    private IEnumerator WritingText()
    {
        string message = "";

        foreach (char character in uiText)
        {
            yield return new WaitForSeconds(1);
            message = message + uiText;

            _uiText.text = $"{message}";
        }

        
    }
    */
}
