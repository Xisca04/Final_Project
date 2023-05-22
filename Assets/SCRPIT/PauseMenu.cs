using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject btnPause;
    [SerializeField] GameObject panelPauseMenu;

    public void Pause()
    {
        Time.timeScale = 0f;
        btnPause.SetActive(false);
        panelPauseMenu.SetActive(true);
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        btnPause.SetActive(true);
        panelPauseMenu.SetActive(false);
    }

}
