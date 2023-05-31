using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Pause menu with functions buttons

    [SerializeField] GameObject btnPause;
    [SerializeField] GameObject panelPauseMenu;

    // Audio
    private AudioSource _audioSource;
    public AudioClip soundPause;
    public AudioClip soundResume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        btnPause.SetActive(false);
        panelPauseMenu.SetActive(true);
        
        _audioSource.PlayOneShot(soundPause);
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        btnPause.SetActive(true);
        panelPauseMenu.SetActive(false);
        _audioSource.PlayOneShot(soundResume);
    }

}
