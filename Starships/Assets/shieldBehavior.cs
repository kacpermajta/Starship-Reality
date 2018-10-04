using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBehavior : MonoBehaviour {
	public  float health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void hit(float damage, Vector3 odrzut)
	{
		health -= damage;
		if (health < 0f) 
		{
			

			//Destroy(charCanvas);

			Destroy(gameObject);



		}
	}
}
