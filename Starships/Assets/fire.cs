using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

	public GameObject missilePrefab;
	public GameObject shield;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float autoshoot(GameObject target, float exhaust)
	{
		Vector3 location = gameObject.transform.InverseTransformPoint (target.transform.position);
		Vector3 neededRot=new Vector3(0f,0f,0f);
		if (location.x < -1)
			neededRot.y = -1;
		else if
			(location.x > -1)
			neededRot.y = 1;
		
		if (location.y < -1)
			neededRot.x = 1;
		else if
			(location.y > -1)
			neededRot.x = -1;
		gameObject.transform.Rotate (neededRot);

		if ((Mathf.Abs (location.x) + Mathf.Abs (location.y)) / Mathf.Abs (location.z) < 0.01f)
		{
			//shield.tag = "offline";
			if (shield != null) {
				shield.active = false;
				StartCoroutine (resetShield ());
			}
			GameObject.Instantiate (missilePrefab, gameObject.transform.position, (gameObject.transform.rotation));
			return exhaust/10f;
		}
		return 0f;
	}

	public void shoot()
	{
		//shield.tag = "offline";
		if (shield != null) {
			shield.active = false;
			StartCoroutine (resetShield ());
		}
		GameObject.Instantiate(missilePrefab, gameObject.transform.position,(gameObject.transform.rotation));

	}

	IEnumerator resetShield(){

		yield return new WaitForSeconds(0.5f);
		//shield.tag = "Untagged";
		shield.active = true;


	}



}
