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

    public IEnumerator Desactive() // Active and descative the vignette
    {
        vignette.active = true;
        yield return new WaitForSeconds(2);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;

        yield return new WaitForSeconds(2);
        vignette.active = false;
    }
}