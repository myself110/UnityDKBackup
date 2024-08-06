using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerLayoutScript : MonoBehaviour
{

    public JoystickCarControl JoystickScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void calloutchange()
    {
        GameObject stringToggleObject = GameObject.FindWithTag("DonkeyCar");
        JoystickScript = stringToggleObject.GetComponent<JoystickCarControl>();
        Debug.Log(JoystickScript);
        JoystickScript.ToggleLayout();
        Debug.Log("Changed2");
    }*/
}
