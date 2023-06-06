using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsAudioLoader : MonoBehaviour
{
    // Save button of slider

    public string key;

    public void SetFloat(float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
}
