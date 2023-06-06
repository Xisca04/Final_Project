using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    // Audio v.2

    public GameObject cam;
    private AudioSource _audioSource;
    public Slider _sliderBackground;
    public float musicVolume;

    //public float music;
    //private string musicName = "BackgroundMusic";

    private void Start()
    {
        _audioSource = cam.GetComponent<AudioSource>();
    }
    /*
    public void VolumeMusic(float value)
    {
        _audioSource.volume = value; 
    }
    */
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            _sliderBackground.value = PlayerPrefs.GetFloat("Volume");
        }
    }


    private void Update()
    {

        _audioSource.volume = musicVolume;

    }


    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("Volume", vol);

    }
}
