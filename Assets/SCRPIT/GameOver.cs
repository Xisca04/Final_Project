using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Game Over

    public GameObject gameOverPanel;
    private float yMin = -2;
    
    // Communication script
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
        else if(_playerController.transform.position.y < yMin)
        {
            GameOverLevels();
        }
    }

    public void GameOverLevels()
    {
        gameOverPanel.SetActive(true);
        _playerController.dirtParticle.Stop();
        _playerController.timer = 0;
    }

    
       
}

