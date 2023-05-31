using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public static class CorrutinaText
{
    // Courutine of the text message

    public static IEnumerator WritingText(string uiText, TextMeshProUGUI textBox)
    {
        textBox.text = "";

        foreach(char character in uiText)
        {
            textBox.text = textBox.text + character;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
