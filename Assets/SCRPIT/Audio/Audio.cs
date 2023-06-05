using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Audio v.2

    public GameObject cam;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = cam.GetComponent<AudioSource>(); 
    }

    public void VolumeMusic(float value)
    {
        _audioSource.volume = value; 
    }

}
