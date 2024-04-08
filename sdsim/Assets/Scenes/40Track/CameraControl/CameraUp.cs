using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUp : MonoBehaviour
{

    private Vector3 moveZ = new Vector3(0, 0, 0.1f);
    private Vector3 moveX = new Vector3(0, 0.1f, 0);
    public float degreesPerPress = 5f; // Degrees to rotate each press
    public float TestVariable = 0f;
    public GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Cam.transform.localPosition += moveZ;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Cam.transform.localPosition -= moveZ;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Cam.transform.localPosition += moveX;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Cam.transform.localPosition -= moveX;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Cam.transform.Rotate(-degreesPerPress, 0, 0, Space.Self);
        }

        // Rotate positively (right) around the local Y-axis with the Y key
        if (Input.GetKeyDown(KeyCode.G))
        {
            Cam.transform.Rotate(degreesPerPress, 0, 0, Space.Self);
        }
    }

    public void MoveCameraUp()
    {
        Cam.transform.localPosition += new Vector3(0, 1f, 0);
    }
    public void MoveCameraDown()
    {
        Cam.transform.localPosition += new Vector3(0, -1f, 0);
    }
}
