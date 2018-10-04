using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class blink : MonoBehaviour {

	public float time;
	public float lifetime, prevTime, dTime;
	// Use this for initialization
	void Start () {
		lifetime = 0f;
		prevTime = Time.time;
//		InvokeRepeating (FUpdateF, 0, 0.5);
	}
	
	// Update is called once per frame
	void Update () {

		dTime=Time.time- prevTime ;
		lifetime +=dTime;
		prevTime = Time.time;
		if (lifetime> time  )
			Destroy (gameObject);
		else if (lifetime > time / 2) 
		{
			gameObject.GetComponent<Light> ().intensity -=  16f/ (time /dTime);
		} 
		else 
		{
			gameObject.GetComponent<Light> ().intensity += 16f/ (time /dTime);
		}

	}
}
