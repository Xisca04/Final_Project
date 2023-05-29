using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentationPanel : MonoBehaviour
{
    public GameObject panelPresenation;
    [SerializeField] private PlayerController _playerController;
    [TextArea]public string _tutorialMessage;
    public TextMeshProUGUI text;

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
