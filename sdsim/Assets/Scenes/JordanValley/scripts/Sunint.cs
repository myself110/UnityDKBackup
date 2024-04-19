using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sunint : MonoBehaviour
{
    public Light sun;
    public Slider slider;
    public Text valueDisplay;

    public float minLight = 0.8f;
    public float maxLight = 2f;

    public float speedRate = 1f;

    private bool autoChangeActive = false; // To control the start/stop of the coroutine


    // Start is called before the first frame update
    void Start()
    {
      slider.value = sun.intensity;

        slider.onValueChanged.AddListener(delegate { UpdateSunIntensity(slider.value); });
        UpdateValueDisplay(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSunIntensity(float value)
    {
        // Set the light's intensity based on the slider's value
        sun.intensity = value;
        UpdateValueDisplay(value);

    }
    void UpdateValueDisplay(float value)
    {
        // Update the text component to show the current slider value, formatted to a desired number of decimal places
        valueDisplay.text = value.ToString("0.00");
    }

    public void ToggleAutoIntensityChange()
    {
        autoChangeActive = !autoChangeActive; // Toggle the state

        if (autoChangeActive)
        {
            StartCoroutine(AutoChangeSunIntensity());
        }
        else
        {
            StopCoroutine(AutoChangeSunIntensity());
        }
    }
    IEnumerator AutoChangeSunIntensity()
    {
        float currentLerpTime = 0f;
        float lerpTime = speedRate; // Time in seconds to complete a single lerp from min to max or max to min
        bool increasingIntensity = true; // Direction of intensity change

        while (autoChangeActive)
        {
            // Calculate the percentage of the lerp time that has passed
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime;

            // Adjust intensity based on the direction of change
            sun.intensity = increasingIntensity ?
                Mathf.Lerp(minLight, maxLight, perc) :
                Mathf.Lerp(maxLight, minLight, perc);

            slider.value = sun.intensity; // Update the slider value to reflect the change
            UpdateValueDisplay(sun.intensity); // Update the display

            // Change direction at the end of each lerp
            if (currentLerpTime == lerpTime)
            {
                increasingIntensity = !increasingIntensity;
                currentLerpTime = 0f;
            }

            yield return null;
        }
    }

}
