using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POVscriot : MonoBehaviour
{
    public GameObject GroundPOV; // The game object to attach the camera to
    public GameObject SpectatorPOV;
    private GameObject cameraGameObject;
    public bool ToggleCameraAction = false;
    public bool ToggleCameraPOV = false;
    public string targetTag = "DonkeyCar"; // Tag of the object to look at
    public GameObject CarTarget;
    public bool Cameraisspawned = false;




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Cameraisspawned == true)
        {
            cameraGameObject.transform.LookAt(CarTarget.transform);
        } 
        else
        {
            return;
        }
        
    }

    public void spawncamera()
    {
        if (GroundPOV != null)
        {
            // Create a new camera object
            cameraGameObject = new GameObject("POVCamera");
            Camera newCamera = cameraGameObject.AddComponent<Camera>();

            // Set the camera's position and orientation based on the target object
            cameraGameObject.transform.SetParent(GroundPOV.transform);
            cameraGameObject.transform.localPosition = Vector3.zero; // Position the camera at the center of the target object
            cameraGameObject.transform.localRotation = Quaternion.identity; // Align the camera's rotation with the target object

            // Additional camera settings
            newCamera.clearFlags = CameraClearFlags.Skybox;
            newCamera.nearClipPlane = 0.3f;
            newCamera.farClipPlane = 100000;
            newCamera.fieldOfView = 20;

            CarTarget = GameObject.FindGameObjectWithTag(targetTag);
            if (CarTarget == null)
            {
                Debug.LogError("No object found with the tag " + targetTag);
                return;
            }


        }
        else
        {
            Debug.LogError("Target object not assigned.");
        }

        Cameraisspawned = true;
    }

    public void DestroyCamera()
    {
        if (cameraGameObject != null)
        {
            Destroy(cameraGameObject);
            Cameraisspawned = false;
        }
    }

    public void ToggleCameraFunction()
    {
        if (ToggleCameraAction == false)
        {
            ToggleCameraAction = true;
            spawncamera();

        } else if (ToggleCameraAction == true)
        {
            ToggleCameraAction = false;
            DestroyCamera();
        }
    }

    public void switchPOV()
    {
        if (ToggleCameraPOV == false)
        {
            ToggleCameraPOV = true;
            // Set the camera's position and orientation based on the target object
            cameraGameObject.transform.SetParent(SpectatorPOV.transform);
            cameraGameObject.transform.localPosition = Vector3.zero; // Position the camera at the center of the target object
            cameraGameObject.transform.localRotation = Quaternion.identity; // Align the camera's rotation with the target object

        } else if (ToggleCameraPOV == true)
        {
            ToggleCameraPOV = false;
            // Set the camera's position and orientation based on the target object
            cameraGameObject.transform.SetParent(GroundPOV.transform);
            cameraGameObject.transform.localPosition = Vector3.zero; // Position the camera at the center of the target object
            cameraGameObject.transform.localRotation = Quaternion.identity; // Align the camera's rotation with the target object
        }
    }


}
