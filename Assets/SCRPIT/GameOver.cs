using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Game Over
    public GameObject gameOverPanel;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
       _playerController = FindObjectOfType<PlayerController>();
        
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if(_playerController.timer == 0) 
        {
            GameOverLevels();
        }
    }

    public void GameOverLevels()
    {
        gameOverPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.H))
        {
            gameOverPanel.SetActive(false);
        }
    }
}
