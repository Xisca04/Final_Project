using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }


    
}
