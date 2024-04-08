using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightToggleScript : MonoBehaviour
{
    public Light[] lights; // Assign all your lights in the inspector
    public Renderer[] emissiveRenderers; // Assign corresponding emissive renderers in the inspector
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    private bool isIncreasing = true;
    public float changeRate = 0.5f; // Speed of change
    private bool isLightOn = true; // Light state

    public Slider intensitySlider; // Assign in inspector
    public Text sliderValueText; // Assign in inspector

    public float minEmissiveIntensity = 0.1f; // Minimum emissive intensity
    public float maxEmissiveIntensity = 1f; // Maximum emissive intensity
    private Color[] baseEmissionColors; // Store the original emission colors

    void Start()
    {
        baseEmissionColors = new Color[emissiveRenderers.Length];
        for (int i = 0; i < emissiveRenderers.Length; i++)
        {
            if (emissiveRenderers[i] != null)
            {
                // Store the base emission color of each emissive material
                baseEmissionColors[i] = emissiveRenderers[i].material.GetColor("_EmissionColor");
            }
        }
        intensitySlider.onValueChanged.AddListener(OnSliderValueChanged);
        sliderValueText.text = intensitySlider.value.ToString("0.00");
    }

    void OnSliderValueChanged(float value)
    {
        // Update all lights based on the slider value
        foreach (Light light in lights)
        {
            light.intensity = Mathf.Lerp(minIntensity, maxIntensity, value);
        }

        // Update all emissive materials based on the slider value
        for (int i = 0; i < emissiveRenderers.Length; i++)
        {
            float emissiveIntensity = Mathf.Lerp(minEmissiveIntensity, maxEmissiveIntensity, value);
            Color finalEmissiveColor = baseEmissionColors[i] * Mathf.LinearToGammaSpace(emissiveIntensity);
            emissiveRenderers[i].material.SetColor("_EmissionColor", finalEmissiveColor);
            DynamicGI.SetEmissive(emissiveRenderers[i], finalEmissiveColor);
        }
        if (sliderValueText != null)
        {
            // Format the value to a string with desired precision, e.g., "0.00" for two decimal places
            sliderValueText.text = value.ToString("0.00");
        }
    }

    void Update()
    {
        if (!isLightOn) return; // Skip updating if lights are off

        foreach (Light light in lights)
        {
            // Adjust light intensity for each light
            float intensityDelta = (isIncreasing ? 1 : -1) * changeRate * Time.deltaTime;
            light.intensity += intensityDelta;

            if (light.intensity >= maxIntensity || light.intensity <= minIntensity)
            {
                isIncreasing = !isIncreasing; // Change direction once any light hits the boundary
                break; // Assume all lights change direction at the same time
            }
        }

        // Update emissive intensity based on the first light's current intensity as a reference
        for (int i = 0; i < emissiveRenderers.Length; i++)
        {
            if (emissiveRenderers[i] != null)
            {
                float emissiveIntensityRatio = (lights[0].intensity - minIntensity) / (maxIntensity - minIntensity);
                float emissiveIntensity = Mathf.Lerp(minEmissiveIntensity, maxEmissiveIntensity, emissiveIntensityRatio);
                Color finalEmissiveColor = baseEmissionColors[i] * Mathf.LinearToGammaSpace(emissiveIntensity);
                emissiveRenderers[i].material.SetColor("_EmissionColor", finalEmissiveColor);
                DynamicGI.SetEmissive(emissiveRenderers[i], finalEmissiveColor);
            }
        }
    }

    public void ToggleLight()
    {
        isLightOn = !isLightOn;
        foreach (Light light in lights)
        {
            light.intensity = isLightOn ? minIntensity : 3; // Turn lights off or reset to min
        }
        for (int i = 0; i < emissiveRenderers.Length; i++)
        {
            if (!isLightOn && emissiveRenderers[i] != null)
            {
                emissiveRenderers[i].material.SetColor("_EmissionColor", Color.white);
                DynamicGI.SetEmissive(emissiveRenderers[i], Color.white);
            }
            else if (isLightOn && emissiveRenderers[i] != null)
            {
                Color initialEmissiveColor = baseEmissionColors[i] * Mathf.LinearToGammaSpace(minEmissiveIntensity);
                emissiveRenderers[i].material.SetColor("_EmissionColor", initialEmissiveColor);
                DynamicGI.SetEmissive(emissiveRenderers[i], initialEmissiveColor);
            }
        }
    }
}