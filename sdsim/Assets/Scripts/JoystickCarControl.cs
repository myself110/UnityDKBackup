﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JoystickCarControl : MonoBehaviour 
{
	public GameObject carObj;
	private ICar car;

	public float MaximumSteerAngle = 25.0f; //has to be kept in sync with the car, as that's a private var.

	//Choose between 2 Input manager Controllers
	//public string Ps4Layout = "HorizontalPS4";
	//public string PCLayout = "Horizontal";

	//public string ContLayout;
	void Awake()
	{
		if(carObj != null)
			car = carObj.GetComponent<ICar>();
		//ContLayout = PCLayout;
	}

    private void OnDisable()
    {
        car.RequestThrottle(0.0f);
		car.RequestHandBrake(1.0f);
		car.RequestFootBrake(1.0f);
    }
	private void FixedUpdate()
	{
		// pass the input to the car!
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		float handbrake = CrossPlatformInputManager.GetAxis("Jump");
		car.RequestSteering(h * MaximumSteerAngle);
		car.RequestThrottle(v);
		//car.RequestFootBrake(v);
		car.RequestHandBrake(handbrake);
	}

	//public void ToggleLayout()
    //{
	//	Debug.Log("Changed");
	//	if (ContLayout == PCLayout)
	//	{
	//		ContLayout = Ps4Layout;
	//	}
//else if (ContLayout == Ps4Layout)
    //    {
	//		ContLayout = PCLayout;
     //   }
    //}
}
