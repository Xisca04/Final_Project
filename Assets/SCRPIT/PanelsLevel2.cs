using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelsLevel2 : MonoBehaviour
{
    public GameObject panelPresenation;
    public GameObject panelWarning;
    [SerializeField] private PlayerController _playerController;
    [TextArea] public string _tutorialMessage;
    public TextMeshProUGUI text;

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
