using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class controller : MonoBehaviour {
	
	public static bool moveUp;
	public static bool moveDown;
	public static bool moveLeft;
	public static bool moveRight;
	public static bool Strike;
	public static bool Skill;
	public static bool Boost;
	public static bool Clockwise,ConClockwise;
	public static bool alive;
//	public static int message;




//	public static float cameraPlane;




	// Use this for initialization
	void Start () {
		alive = true;
	//	message = 0;
	}
	
	// Update is called once per frame
	void Update () {



       
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}


		if (playerSettings.mobile) 
		{
			moveUp = moveDown = false;
			if(Input.acceleration.x>0f)
				moveUp = true;
			if(Input.acceleration.x>0f)
				moveDown = true;

		} else {
			if (Input.GetKey (KeyCode.Space))
				Boost = true;
			else
				Boost = false;
		



			if (Input.GetKey (KeyCode.W))
				moveUp = true;
			else
				moveUp = false;
			if (Input.GetKey (KeyCode.S))
				moveDown = true;
			else
				moveDown = false;

			if (Input.GetKey (KeyCode.A))
				moveLeft = true;
			else
				moveLeft = false;
		
			if (Input.GetKey (KeyCode.D))
				moveRight = true;
			else
				moveRight = false;
			if (Input.GetKey (KeyCode.Mouse0)) {
				Strike = true;
				Skill = false;
			} else if (Input.GetKey (KeyCode.Mouse1)) {
				Skill = true;
				Strike = false;
			} else {
				Skill = false;
				Strike = false;
			}

			if (Input.GetKey (KeyCode.Q))
				Clockwise = true;
			else
				Clockwise = false;
		
			if (Input.GetKey (KeyCode.E))
				ConClockwise = true;
			else
				ConClockwise = false;

		}
	}




		
}


//	public static void ShowDelayed(){
//
//		StartCoroutine(controller.DelayedInfo ());
//	}
//
//
//	public static IEnumerator DelayedInfo(){
//
//		yield return new WaitForSeconds(3f);
//		controller.message = 2;
//		controller.changeMessage = true;
//	}


