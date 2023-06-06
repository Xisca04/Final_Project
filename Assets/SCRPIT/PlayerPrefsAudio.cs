using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
public class PlayerPrefsAudio : MonoBehaviour
{
    [SerializeField] private string key = "Background";
    [SerializeField] private float defaultValue = 0.5f;
    [SerializeField] private FloatEvent onValueLoaded;

    private void Awake()
    {
        onValueLoaded.Invoke(PlayerPrefs.GetFloat("Background", defaultValue));
    }
}
