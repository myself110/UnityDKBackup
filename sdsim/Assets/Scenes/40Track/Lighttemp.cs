using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necessary for UI interaction if using a button to toggle

public class Lighttemp : MonoBehaviour
{
    public Light[] lights; // Assign all your lights in the inspector

    public Color whiteColor = Color.white;
    public Color warmColor = new Color(1f, 0.42f, 0.04f);
    public Color coolColor = new Color(0.5f, 0.75f, 1f);

    public float transitionDuration = 2f;
    private float transitionTimer = 0f;
    private int colorStage = 0;

    private bool isTransitionActive = false; // Toggle variable

    void Update()
    {
        if (isTransitionActive)
        {
            transitionTimer += Time.deltaTime;
            float lerpFactor = transitionTimer / transitionDuration;

            foreach (Light light in lights)
            {
                // Apply the color transition to each light in the array
                if (colorStage == 0)
                {
                    light.color = Color.Lerp(whiteColor, warmColor, lerpFactor);
                }
                else if (colorStage == 1)
                {
                    light.color = Color.Lerp(warmColor, coolColor, lerpFactor);
                }
                else if (colorStage == 2)
                {
                    light.color = Color.Lerp(coolColor, whiteColor, lerpFactor);
                }
            }

            if (lerpFactor >= 1f)
            {
                transitionTimer = 0f;
                colorStage = (colorStage + 1) % 3;
            }
        }
    }

    public void ToggleTransition()
    {
        isTransitionActive = !isTransitionActive;
        if (!isTransitionActive)
        {
            transitionTimer = 0f;
            colorStage = 0;
            // Optionally reset all lights to the initial color when toggled off
            foreach (Light light in lights)
            {
                light.color = whiteColor;
            }
        }
    }
}