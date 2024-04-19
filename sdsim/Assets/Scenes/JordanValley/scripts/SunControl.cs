using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunControl : MonoBehaviour
{
    public Light sun; // Assign your directional light here
    public Slider slider; // Assign your UI Slider here

    public Button rotationToggleButton; // Assign your UI Button here for toggling rotation

    public Vector3 startRotation = new Vector3(50, 0, 0); // Starting rotation
    public Vector3 endRotation = new Vector3(120, 0, 0); // Ending rotation

    public float minSliderValue = 0f; // Minimum value of the slider
    public float maxSliderValue = 10f; // Maximum value of the slide

    // New color control
    public Color startColor = new Color(1f, 0.8f, 0.6f); // Warm morning light
    public Color endColor = new Color(0.5f, 0.5f, 1f); // Cool evening light

    private bool autoRotate = false; // Flag for toggling automatic rotation

    public float autoRotationSpeed = 1f; // Control the speed of automatic rotation

    // Start is called before the first frame update
    void Start()
    {
        // Set the slider's range
        slider.minValue = minSliderValue;
        slider.maxValue = maxSliderValue;
        slider.value = minSliderValue; // Optionally, reset the slider to its minimum value at start

        // Ensure the slider has a listener for value changes that calls the UpdateSunRotation method
        slider.onValueChanged.AddListener(delegate { UpdateSunRotation(); });
        slider.onValueChanged.AddListener(delegate { UpdateSunProperties(); });
        rotationToggleButton.onClick.AddListener(ToggleAutoRotation);


        UpdateSunProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateSunRotation()
    {
        if (!autoRotate) // Only manually update rotation if autoRotate is false
        {
            // Interpolate sun's rotation based on the slider's value
            float lerpFactor = (slider.value - minSliderValue) / (maxSliderValue - minSliderValue);
            sun.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, lerpFactor));
            UpdateSunProperties(); // Update color along with rotation
        }
    }
    void UpdateSunProperties()
    {
        // Calculate the interpolation factor based on the slider's current value
        float lerpFactor = (slider.value - minSliderValue) / (maxSliderValue - minSliderValue);

        // Interpolate and update the sun's rotation
        sun.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, lerpFactor));

        // Interpolate and update the sun's light color
        sun.color = Color.Lerp(startColor, endColor, lerpFactor);
    }
    void ToggleAutoRotation()
    {
        autoRotate = !autoRotate;
        if (autoRotate)
        {
            StartCoroutine(AutoRotateSun());
        }
        else
        {
            StopCoroutine(AutoRotateSun());
        }
    }
    IEnumerator AutoRotateSun()
    {
        float time = 0f;
        while (autoRotate)
        {
            // Modify the line with Mathf.Sin(time * Mathf.PI / 10) to include autoRotationSpeed
            slider.value = Mathf.Lerp(minSliderValue, maxSliderValue, Mathf.Sin(time * Mathf.PI * autoRotationSpeed) * 0.5f + 0.5f);
            time += Time.deltaTime;
            yield return null;
        }
    }

}
