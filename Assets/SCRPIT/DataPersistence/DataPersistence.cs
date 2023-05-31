using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    // Data Persistence to save the username

    public static DataPersistence sharedInstance;
    public string username;

    private void Awake()  
    {
        if (sharedInstance == null)  
        {
            sharedInstance = this; 
            DontDestroyOnLoad(this); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
