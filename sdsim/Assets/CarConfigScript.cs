using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarConfigScript : MonoBehaviour
{
    public float CarSpeed = 30f;
    public float CarDrag = 1f;
    //public float CarMass = 50;
    public float CarSteer = 10.5f;
    public float CameraAngle = 15f;
    //public float CameraFOV = 120f;
    //public float FisheyeStrengthX = 0.6f;


    public Slider MaxSpeedSlider;
    public Text MaxSpeedText;

    public Slider MaxDragSlider;
    public Text MaxDragText;

    //public Slider MaxMassSlider;
    //public Text MaxMassText;

    public Slider MaxSteerSlider;
    public Text MaxSteerText;

    public Slider MaxCameraAngleSlider;
    public Text MaxCameraAngleText;

   // public Slider MaxCameraFOVSlider;
    //public Text MaxCameraFOVText;

    public bool AngleToggle = false;
    public float speed = 1f;

    public Material BGbackgroundColor;
    public bool ColorToggleBool = false;
    public Color myColor;

    //public Slider FisheyeXSlider;
    //public Text FisheyeXText;

    //public Slider FisheyeYSlider;
    //public Text FisheyeYText;
    // Start is called before the first frame update
    void Start()
    {
        MaxSpeedSlider.onValueChanged.AddListener(UpdateMaxSpeedSlider);
        UpdateMaxSpeedSlider(MaxSpeedSlider.value);

        MaxDragSlider.onValueChanged.AddListener(UpdateMaxDragSlider);
        UpdateMaxDragSlider(MaxDragSlider.value);

        MaxSteerSlider.onValueChanged.AddListener(UpdateMaxSteerSlider);
        UpdateMaxSteerSlider(MaxSteerSlider.value);

        MaxCameraAngleSlider.onValueChanged.AddListener(UpdateCamAngleSlider);
        UpdateCamAngleSlider(MaxCameraAngleSlider.value);

       // MaxCameraFOVSlider.onValueChanged.AddListener(UpdateCamFOVslider);
        //UpdateCamFOVslider(MaxCameraFOVSlider.value);

        /* MaxMassSlider.onValueChanged.AddListener(UpdateMaxMassSlider);
        UpdateMaxMassSlider(MaxMassSlider.value);
        MaxMassSlider.value = 50f;*/

        //FisheyeXSlider.onValueChanged.AddListener(UpdateFisheyeHorSlider);
        //UpdateFisheyeHorSlider(FisheyeXSlider.value);

    }

    // Update is called once per frame
    void Update()
    {
        if (AngleToggle == true)
        {
            // Calculate the oscillation value using the sine of time
            float angle = Mathf.Sin(Time.time * speed) * 15; // Oscillates between -15 and 15

            CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
            // Apply the oscillation to the GameObject's rotation on the X axis
            CameraSensorObject.transform.rotation = Quaternion.Euler(angle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            MaxCameraAngleSlider.value = angle;
        }
    }

    

    void UpdateMaxSpeedSlider(float value)
    {

        MaxSpeedText.text = value.ToString("0.##"); // Same logic for updating the text
        CarSpeed = value;
    }

    void UpdateMaxDragSlider(float value)
    {

        MaxDragText.text = value.ToString("0.##"); // Same logic for updating the text
        CarDrag = value;
    }

    //void UpdateMaxMassSlider(float value)
    //{

    //    MaxMassText.text = value.ToString("0.##"); // Same logic for updating the text
    //    CarMass = value;
    //}

    void UpdateMaxSteerSlider(float value)
    {

        MaxSteerText.text = value.ToString("0.##"); // Same logic for updating the text
        CarSteer = value;
    }

    void UpdateCamAngleSlider(float value)
    {
        //Debug.Log("Triggered");
        MaxCameraAngleText.text = value.ToString("0.##"); // Same logic for updating the text
        CameraAngle = value;
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localEulerAngles = (new Vector3(value, 0, 0)); 
    }
    
    //void UpdateCamFOVslider(float value)
   // {
     //   Debug.Log("Triggereddd");
//MaxCameraFOVText.text = value.ToString("0.##");
//CameraFOV = value;
//CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        //Camera camera = CameraSensorObject.GetComponent<Camera>();
      //  camera.fieldOfView = value;
    //}

    //void UpdateFisheyeHorSlider(float value)
    //{
    //    Debug.Log("Triggered");
    //    FisheyeXText.text = value.ToString("0.##"); // Same logic for updating the text
    //    //FisheyeStrengthX = value;
    //    //UnityStandardAssets.ImageEffects.Fisheye fisheye = GameObject.FindObjectOfType<UnityStandardAssets.ImageEffects.Fisheye>();
    //    //fisheye.strengthX = value;
    //}

    public void ConfigCar()
    {
        Car carspeed = GameObject.FindObjectOfType<Car>();
        carspeed.maxSpeed = CarSpeed;
        carspeed.maxSteer = CarSteer;
        GameObject CarRigidBody = GameObject.FindGameObjectWithTag("DonkeyCar");
        Debug.Log(CarRigidBody);
        Rigidbody rb = CarRigidBody.GetComponent<Rigidbody>();
        rb.drag = CarDrag;
        //rb.mass = CarMass;

    }

    public void CameraMove25cm()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, 1.5625f, CameraSensorObject.transform.localPosition.z);
    }
    public void CameraMove22cm()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, 1.40625f, CameraSensorObject.transform.localPosition.z);
    }
    public void CameraMove19cm()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, 1.1875f, CameraSensorObject.transform.localPosition.z);
    }

    public void CameraMove15cm()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, 0.9375f, CameraSensorObject.transform.localPosition.z);
    }

    public void CameraMove14cm()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, 0.875f, CameraSensorObject.transform.localPosition.z); ;
    }

    

    public void CameraMoveFront()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, CameraSensorObject.transform.localPosition.y, 0.73f); ;
    }

    public void CameraMoveMid()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, CameraSensorObject.transform.localPosition.y, -0.159f); ;
    }

    public void CameraMoveBack()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localPosition = new Vector3(CameraSensorObject.transform.localPosition.x, CameraSensorObject.transform.localPosition.y, -1.047f); ;
    }

    public void ResetCamAngle()
    {
        CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
        CameraSensorObject.transform.localEulerAngles = (new Vector3(15f, 0, 0));
        MaxCameraAngleSlider.value = 15f;
    }

   // public void CameraFovChange()
   // {
   //     CameraSensor CameraSensorObject = GameObject.FindObjectOfType<CameraSensor>();
   //     Camera camera = CameraSensorObject.GetComponent<Camera>();
   //     //camera.fieldOfView =
   // }


    public void AngleToggleFuction()
    {
        if(AngleToggle == true)
        {
            AngleToggle = false;
        } else if (AngleToggle == false)
        {
            AngleToggle = true;
        }
    }

    public void Togglecolor()
    {

        if (ColorToggleBool == false)
        {
            BGbackgroundColor.color = Color.gray;
            ColorToggleBool = true;
        }
        else if (ColorToggleBool == true)
        {
            BGbackgroundColor.color = myColor;
            ColorToggleBool = false;
        }
        
    }

    

}

