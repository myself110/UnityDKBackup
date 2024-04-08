using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sun_cloud : MonoBehaviour
{
    public Light sun;
    public Slider shadowStrengthSlider;
    public Text shadowValue;

  
    // Start is called before the first frame update
    void Start()
    {
        shadowStrengthSlider.value = sun.shadowStrength;

        shadowValue.text = sun.shadowStrength.ToString("0.00");

        shadowStrengthSlider.onValueChanged.AddListener(delegate { UpdateShadowStrength(shadowStrengthSlider.value); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateShadowStrength(float value)
    {
        sun.shadowStrength = value;

        shadowValue.text = value.ToString("0.00");
    }




}
