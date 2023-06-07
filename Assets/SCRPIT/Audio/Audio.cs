using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    // Volume audio of the background music

    public GameObject cam;
    private AudioSource _audioSource;
    public Slider _sliderBackground;
    public float musicVolume;

    private void Start()
    {
        _audioSource = cam.GetComponent<AudioSource>();
    }

    
    public void VolumeMusic(float value)
    {
        _audioSource.volume = value; 
    }
    
}
