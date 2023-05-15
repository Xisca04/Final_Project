using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public float timerTimer;
    public TextMeshProUGUI textTime;


    private void Update()
    {
        timerTimer -= Time.deltaTime;
        textTime.text = "" + timerTimer.ToString("f1");

        if(timerTimer <= 0)
        {
            timerTimer = 0;
        }
    }

}
