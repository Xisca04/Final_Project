using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessing : MonoBehaviour
{
    // Post processing -- vignette

    private Volume volume;
    [SerializeField] private Vignette vignette;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    private void Start()
    {
        volume.profile.TryGet(out vignette); 
    }

    public IEnumerator Desactive() // Descative the vignette
    {
        yield return new WaitForSeconds(0.1f);
        //vignette.intensity.value = 0.5f;
        vignette.active = false;
    }

    public IEnumerator Active() // Active the vignette
    {
        vignette.active = true;
        yield return new WaitForSeconds(1f);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;
    }
}