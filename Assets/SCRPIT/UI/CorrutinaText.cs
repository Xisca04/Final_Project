using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public static class CorrutinaText
{
    // Corrutina texto - máquina escribir

    

    public static IEnumerator WritingText(string uiText, TextMeshProUGUI textBox)
    {
        textBox.text = "";

        foreach(char character in uiText)
        {
            textBox.text = textBox.text + character;
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
