using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelsLevel2 : MonoBehaviour
{
    // Panels level 2

    public GameObject panelPresenation;
    public GameObject panelWarning;
    [TextArea] public string _tutorialMessage;
    public TextMeshProUGUI text;
    
    // Communication script
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();

        panelPresenation.SetActive(true);
        panelWarning.SetActive(false);
        _playerController.enabled = false;
        StartCoroutine(CorrutinaText.WritingText(_tutorialMessage, text));
    }
    
    public void PresentationButton()
    {
        panelPresenation.SetActive(false);
        panelWarning.SetActive(true);
    }

    public void WarningButton()
    {
        panelPresenation.SetActive(false);
        panelWarning.SetActive(false);
        _playerController.enabled = true;
    }
}
