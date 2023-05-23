using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager2 : MonoBehaviour
{

    public TextMeshProUGUI welcomeText;

    private void Start()
    {
        welcomeText.text = $"Welcome, {DataPersistence.sharedInstance.username}";
    }
}
