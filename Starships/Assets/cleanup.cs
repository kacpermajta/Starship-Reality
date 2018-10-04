using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanup : MonoBehaviour {
	public float timeout;
	// Use this for initialization
	void Start () {
		
		StartCoroutine (timeoutClean ());
	}

	IEnumerator timeoutClean(){

		yield return new WaitForSeconds(timeout);
		//shield.tag = "Untagged";
		Destroy(gameObject);


	}
	

}
