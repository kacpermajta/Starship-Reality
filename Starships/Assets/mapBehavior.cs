using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mapTarget
{
	public GameObject targetShip;
	public GameObject targetMark;

	Vector3 Location;
	public bool updateMark(GameObject OriginObj)
	{
		if (targetShip == null) {

			Debug.Log ("ejno");
			return false;
		} else 
		{
			Location = OriginObj.transform.InverseTransformPoint (targetShip.transform.position);
			if (Location.x > 900f)
				Location.x = 900f;			
			if (Location.y > 900f)
				Location.y = 900f;			
			if (Location.z > 900f)
				Location.z = 900f;


			if (Location.x < -900f)
				Location.x = -900f;			
			if (Location.y < -900f)
				Location.y = -900f;			
			if (Location.z < -900f)
				Location.z = -900f;
			targetMark.transform.localPosition = new Vector3 (Location.x / 4000, Location.z / 4000, Location.y / 4000);
		}
		return true;
	}
}
public class mapBehavior : MonoBehaviour 
{
	public List< mapTarget> targetShip;
//	public mapTarget OwnShip;
	public GameObject[] targetShipObj;
	public GameObject mapMarkPrefab;
	// Use this for initialization
	void Start () 
	{
		targetShip=new List<mapTarget>();
		mapTarget newtargetShip=new mapTarget();
		newtargetShip.targetShip = targetShipObj[0];
		newtargetShip.targetMark = Instantiate (mapMarkPrefab, gameObject.transform);
		targetShip.Add (newtargetShip);
		newtargetShip=new mapTarget();
		newtargetShip.targetShip = targetShipObj[1];
		newtargetShip.targetMark = Instantiate (mapMarkPrefab, gameObject.transform);
		targetShip.Add (newtargetShip);
		newtargetShip=new mapTarget();
		newtargetShip.targetShip = targetShipObj[2];
		newtargetShip.targetMark = Instantiate (mapMarkPrefab, gameObject.transform);

		targetShip.Add (newtargetShip);
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool existing;
		foreach (mapTarget myTarget in targetShip)
		{
			existing = myTarget.updateMark (gameObject.transform.parent.gameObject);
			if (!existing) 
			{
				Destroy (myTarget.targetMark);
				targetShip.Remove (myTarget);
				return;
			}	
				
		}
	}
}
