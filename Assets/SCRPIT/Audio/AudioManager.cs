using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Control of the sliders audio

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    private float backgroundFloat, soundEffectsFloat;

    public Slider backgroundSlider, soundEffectsSlider;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) // Main menu backround
        {
            backgroundFloat = 0.25f;
            soundEffectsFloat = 1f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else // Pull the values from the player prefs
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus) // Save the values even if you quit the game
    {
        SaveSoundSettings();
    }
    /*
    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for (int i = 0; i < soundEffectsAudio.Lenght; i++) // we can have any value in that array
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
    */
}
