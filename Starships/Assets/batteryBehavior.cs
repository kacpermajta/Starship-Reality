using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryBehavior : MonoBehaviour {

	public GameObject[] gunModel;
	public GameObject enemy;

	public float stamina, exhaust;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float fullExhaust=0f;
		if (gameObject.transform.InverseTransformPoint (enemy.transform.position).x < 0) 
		{
			
			if (stamina >= 100) 
			{
				
				fullExhaust+=gunModel [3].GetComponent<fire> ().autoshoot (enemy,exhaust);
				fullExhaust+=gunModel [2].GetComponent<fire> ().autoshoot (enemy,exhaust);
				fullExhaust+=gunModel [1].GetComponent<fire> ().autoshoot (enemy,exhaust);
				fullExhaust+=gunModel [0].GetComponent<fire> ().autoshoot (enemy,exhaust);
				stamina -= fullExhaust;

			}
		}
		if (stamina < 100)
			stamina++;
		
	}
}
