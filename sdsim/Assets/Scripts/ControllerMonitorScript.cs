using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMonitorScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HozInp = Input.GetAxis("Horizontal");
        float VerInp = Input.GetAxis("Vertical");

        Debug.Log("LeftRight" + HozInp);
        Debug.Log("F&B" + VerInp);
    }
}
