using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSttings : MonoBehaviour
{
    // Audio Settings to save between scenes

    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;

    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    private void Awake()
    {
        //ContinueSettings();
    }

    /*
    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsAudio.Lenght; i++) // we can have any value in that array
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
    */
}
