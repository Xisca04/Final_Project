using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager2 : MonoBehaviour
{
    // UIManager 2 -- Show the message with the username

    public TextMeshProUGUI welcomeText;

    private void Start()
    {
        welcomeText.text = $"Welcome, {DataPersistence.sharedInstance.username}";
    }
}
