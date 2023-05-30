using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Game Over
    public GameObject gameOverPanel;
    [SerializeField] private PlayerController _playerController;
    private float yMin = -2;

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
        else if(_playerController.transform.position.y < yMin)
        {
            GameOverLevels();
        }
    }

    public void GameOverLevels()
    {
        gameOverPanel.SetActive(true);
        _playerController.dirtParticle.Stop();
        Time.timeScale = 0f;
    }

    
       
}

