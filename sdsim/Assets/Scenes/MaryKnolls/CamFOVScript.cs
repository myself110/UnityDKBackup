using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFOVScript : MonoBehaviour
{
    public float CameraFOV = 120f;
    public Slider MaxCameraFOVSlider;
    public Text MaxCameraFOVText;

    public Slider FisheyeXSlider;
    public Text FisheyeXText;

    public Slider FisheyeYSlider;
    public Text FisheyeYText;

    public float FisheyeStrengthX = 0.6f;
    public float FisheyeStrengthY = 0.3f;

    void Start()
    {

        Debug.Log("executed");
        MaxCameraFOVSlider.onValueChanged.AddListener(UpdateCamFOVslider);
        UpdateCamFOVslider(MaxCameraFOVSlider.value);

        
        Debug.Log("executed2");

        /*FisheyeXSlider.onValueChanged.AddListener(UpdateFisheyeHorSlider);
        UpdateFisheyeHorSlider(FisheyeXSlider.value);
        Debug.Log("executed3");

        FisheyeYSlider.onValueChanged.AddListener(UpdateFisheyeVerSlider);
        UpdateFisheyeVerSlider(FisheyeYSlider.value);
        Debug.Log("executed4");

        FisheyeXText.text = FisheyeStrengthX.ToString("0.6");
        Debug.Log("executed5");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCamFOVslider(float value)
    {
        Debug.Log("Triggereddd");
        MaxCameraFOVText.text = value.ToString("0.##");
        CameraFOV = value;
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        Camera camera = CameraSensorObject.GetComponent<Camera>();
        camera.fieldOfView = value;

        /*if (CameraSensorObject != null)
        {
            // Attempt to get the Camera component from the CameraSensorObject
            Camera camera = CameraSensorObject.GetComponent<Camera>();

            // Check if the Camera component was successfully found
            if (camera != null)
            {
                // If the Camera component is found, update its field of view
                camera.fieldOfView = value;
                Debug.Log("Field of View Updated to " + value);
            }
            else
            {
                // Log a message if the Camera component was not found on the CameraSensorObject
                Debug.LogError("Camera component not found on CameraSensorObject!");
            }
        }
        else
        {
            // Log a message if the CameraSensor object was not found in the scene
            Debug.LogError("CameraSensorObject not found in the scene!");
        }*/
    }
   /* void UpdateFisheyeHorSlider(float value)
    {
        Debug.Log("Triggered");
        FisheyeXText.text = value.ToString("0.##"); // Same logic for updating the text
        FisheyeStrengthX = value;
        UnityStandardAssets.ImageEffects.Fisheye fisheye = GameObject.FindObjectOfType<UnityStandardAssets.ImageEffects.Fisheye>();
      fisheye.strengthX = value;
    }

    void UpdateFisheyeVerSlider(float value)
    {
        Debug.Log("Triggered");
        FisheyeYText.text = value.ToString("0.##"); // Same logic for updating the text
        FisheyeStrengthY = value;
        UnityStandardAssets.ImageEffects.Fisheye fisheye = GameObject.FindObjectOfType<UnityStandardAssets.ImageEffects.Fisheye>();
        fisheye.strengthY = value;
    }*/
    }
