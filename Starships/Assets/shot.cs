﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {
	public float smooth = 2.0F;
	public bool airborne,physical;
	public float velocity;
	Quaternion target;
	public float damage;
	public GameObject flash;
	// Use this for initialization
	void Start () {

	}
	
	void Update () {

//flying missile movement
		if (airborne) {
//			if (transform.eulerAngles.z < 90f|| transform.eulerAngles.z > 270f ) {
//				transform.Rotate (0f, 0f, -0.8f+(2*velocity));
//			} else {
//				transform.Rotate (0f, 0f, 0.8f-(2*velocity));
//			}

			transform.Translate (0f,0f,velocity);

		}
	}




	void OnTriggerEnter(Collider other) 
	//flying missile hit
	{
		if(airborne&&other.tag!="offline")
		{
			Instantiate (flash,gameObject.transform.position,Quaternion.identity);
			if (other.GetComponent< character_behavior > () != null) 
			{

				other.GetComponent< character_behavior > ().hit (damage, transform.eulerAngles);

			}
			if (other.GetComponent<shieldBehavior > () != null) 
			{

				other.GetComponent< shieldBehavior > ().hit (damage, transform.eulerAngles);

			}

			if (physical) 
			{
				Destroy (gameObject.GetComponent<Collider> ());
				Destroy (gameObject.GetComponent<shot> ());
				gameObject.tag = "nonexist";
				if (other.tag == "weapon") 
				{
					//Rigidbody newRigidbody = 
						gameObject.AddComponent<Rigidbody> ();
				} else 
				{
					gameObject.transform.parent = other.transform;
				}
				airborne = false;
			} else if (other.tag != "weapon")
			{
				Destroy (gameObject);
			}
		}
	}

}
