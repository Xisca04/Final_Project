using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentationPanel : MonoBehaviour
{
    // Presentation level 1

    public GameObject panelPresenation;
    [TextArea] public string _tutorialMessage;
    public TextMeshProUGUI text;
    
    //Communication script
    [SerializeField] private PlayerController _playerController;
   
    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();

        panelPresenation.SetActive(true);
        _playerController.enabled = false;
        StartCoroutine(CorrutinaText.WritingText(_tutorialMessage, text));
    }

    public void PresentationPanelLevelOff()
    {
        panelPresenation.SetActive(false);
        _playerController.enabled = true;
    }
}
