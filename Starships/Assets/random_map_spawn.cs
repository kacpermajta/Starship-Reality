using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_map_spawn : MonoBehaviour {
	float xmin, xmax, ymin, ymax, zmin,zmax;
	public GameObject[] entity;
	public GameObject newCharacter;
	public float worldSize;
	Vector3 location;
	// Use this for initialization
	void Start () 
	{
		xmax = ymax = zmax = worldSize;
		xmin = ymin = zmin = -worldSize;
		for(int i=0; i<entity.Length;i++)
		{


			//time to spawn a bot
			int quantity=(int)(Random.value *350);
			for (int j = 0; j < quantity; j++) 
			{
				location = new Vector3 (xmin + (Random.value * (xmax - xmin)), ymin + (Random.value * (ymax - ymin)), zmin + (Random.value * (zmax - zmin)));
//				newCharacter = Instantiate (entity [i], location, Quaternion.identity);
			}


		}
	}
	
	// Update is called once per frame
	void Update () {

//loop through spawned prefabs



	}
}
