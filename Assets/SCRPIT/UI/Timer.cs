using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public float timer;
    public TextMeshProUGUI textTime;

    private void Update()
    {
        timer -= Time.deltaTime;
        textTime.text = "" + timer.ToString("f1");

    }

}
