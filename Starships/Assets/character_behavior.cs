using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_behavior : MonoBehaviour {
	public float exhaust, stamina, turning, speed, baseSpeed, damage, secDamage;
	public GameObject arrow;
	public GameObject explosion, anihilation, deathcam;
	public GameObject[] gunModel;
	public GameObject windshieldModel;
	public GameObject Map;
	public bool exterminate;
	public  float health;

	public Canvas charCanvas;
	public Canvas  textDisplayerPrefab;
	public Text textContent;

	public bool isHostile, isPlayer;


	float x, y, z, jump, orientation;

	Vector3 calcMov;
	public Vector3 location,rotation;
	public GameObject weaponLModel, weaponRModel, frontModel;

	public  bool charUp,charDown, charLeft, charRight, charStrike, charSkill, charClockwise,charConClockwise, charBoost;
	public Vector3 aimError;


	// Use this for initialization
	void Start () {
		location= gameObject.GetComponent<Transform>().position;
//eq initialisation
//		weaponRModel= GameObject.Instantiate(gunModel, location, Quaternion.identity);
//		weaponLModel= GameObject.Instantiate(gunModel, location, Quaternion.identity);
//		weaponRModel.transform.parent = gameObject.transform;
//		weaponLModel.transform.parent = gameObject.transform;
		charCanvas=GameObject.Instantiate(textDisplayerPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity);
//		textDisplayer=new Text
//		turning=0.5f;
		stamina = 100;

//		speed=5f;
		Transform child =  charCanvas.transform.Find("Text");
		textContent = child.GetComponent<Text>();

		//textContent= charCanvas.GetComponent<Text>();

		charCanvas.transform.SetParent (gameObject.transform,false);



		if (health == 0f) 
		{
			health = 15f;
		}
		aimError = new Vector3(0f,0f, 0f);
//		speed = 0.015f;
		charLeft = false;
		charRight = false;
		charUp = false;
		charStrike = false;
		charClockwise= false;
		charConClockwise= false;
	}

	void Update () {



		x *= 0.86f;//drag
		y = -0.13f;//gravity
		jump = 0;
		rotation = new Vector3 (0f, 0f, 0f);

		if (isPlayer) 
		{	
			
//apply controller values
			charBoost=controller.Boost;
			charUp=controller.moveUp;
			charDown=controller.moveDown;
			charRight = controller.moveRight;
			charLeft= controller.moveLeft;
			charStrike = controller.Strike;
			charSkill = controller.Skill;
			charClockwise = controller.Clockwise;
			charConClockwise = controller.ConClockwise;
		}
//movement commends
		if (charBoost)
			speed = 1*baseSpeed;
		else
			speed = 0.6f*baseSpeed;

		if (charRight) {
			rotation.y += turning;

			}
		if (charLeft){
			rotation.y -= turning;

			}

		if (charUp) {
			rotation.x += turning;

		}
		if (charDown){
			rotation.x -= turning;

		}
		if (charClockwise) {
			rotation.z += 2*turning;

		}
		if (charConClockwise){
			rotation.z -= 2*turning;

		}

		if (charStrike && stamina >= 100) 
		{
			gunModel [1].GetComponent<fire> ().shoot ();
			gunModel [0].GetComponent<fire> ().shoot ();
			stamina -= exhaust;

		}
		if (stamina < 100)
			stamina++;

		transform.Translate (0f,0f,speed);
		gameObject.GetComponent<Rigidbody> ().velocity = 0.99f * gameObject.GetComponent<Rigidbody> ().velocity;
		gameObject.GetComponent<Rigidbody> ().angularVelocity = 0.99f * gameObject.GetComponent<Rigidbody> ().angularVelocity;

		gameObject.transform.Rotate (rotation);
		location= gameObject.GetComponent<Transform>().position;

			
//		GameObject missile = GameObject.Instantiate(arrow, guard-new Vector3(0f,0.7f,0f), Quaternion.identity);
		if (exterminate) 
		{
			hit (2000f, new Vector3 ());
			exterminate = false;
		}
	}



//function when character is hit
	public void hit(float damage, Vector3 odrzut)
	{
		health -= damage;
		if (health < 0f) 
		{
			if (isPlayer) 
			{
				controller.alive = false;
			//	controller.ShowDelayed ();
			}
			textContent.text = "";
			//Destroy(charCanvas);


			gameObject.GetComponent< Rigidbody > ().useGravity = true;
			gameObject.GetComponent< Rigidbody > ().isKinematic = false;
			gameObject.GetComponent< Rigidbody > ().AddTorque (odrzut/2);
			//SphereCollider ballCollider = gameObject.AddComponent<SphereCollider>();
			//ballCollider.radius = 0.25f;
			//gameObject.transform.parent = gameObject.transform.parent.transform.parent;
			//GameObject newEplosion = Instantiate (explosion, gameObject.transform);
			GameObject newEplosion = Instantiate (explosion, gameObject.transform);
			//newEplosion.transform.parent = gameObject.transform;
			newEplosion.transform.transform.localPosition=new Vector3();
			newEplosion.transform.localRotation = new Quaternion(0f,-180f,0f,0f);
			//newEplosion.transform.rotation = Quaternion.Euler(new Vector3(0f,-180f,0f));
			//newEplosion.transform.Rotate(new Vector3(0f,180f,0f));
			StartCoroutine (Anihilator ());
			if (isPlayer)
				StartCoroutine (MakeDeathcam ());
		
		}
	}

	IEnumerator MakeDeathcam(){

		yield return new WaitForSeconds(4.5f);
		//Destroy(gameObject.GetComponent< character_behavior > ());


		GameObject newEplosion=Instantiate (deathcam, gameObject.transform);
		newEplosion.transform.transform.localPosition=new Vector3();
		newEplosion.transform.localRotation = new Quaternion(0f,-180f,0f,0f);

	}

	IEnumerator Anihilator(){

		yield return new WaitForSeconds(5f);
		//Destroy(gameObject.GetComponent< character_behavior > ());

		Instantiate (anihilation, gameObject.transform.position, Quaternion.identity);

		Destroy (gameObject, 0.3f);


	}



}
