using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class TWOstaminaMaria : MonoBehaviour
{
    // stamina variables
    public Slider staminaBar;

    private float  maxStamina = 100;
    private float  currentStamina;
    
    public static TWOstaminaMaria  instance;

    public bool hasStamina = true;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        currentStamina -= amount * Time.deltaTime;
        if (currentStamina <= 0)
        {
            currentStamina = 0;
            hasStamina = false;
        }
       
        staminaBar.value = currentStamina;
    }

    public void RegenStamina(int amount)
    {
        if (currentStamina <= 100)
        {
            currentStamina += amount * Time.deltaTime;
            staminaBar.value = currentStamina;

            hasStamina = true;
        }
    }
}
