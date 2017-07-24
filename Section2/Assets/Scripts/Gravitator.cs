using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitator : MonoBehaviour {

	public Gravitate obj;
	private	Vector3 suction;
	private float mass = 3.5f;

	private const float thisForce = 45.845f;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.S)) {
			Gravitating ();
		} else {
			obj.direction = Vector3.zero;
		}
	}

	void Gravitating ()
	{
		Vector3 objdistance = transform.position - obj.transform.position;
		//print("distance " + objdistance);

		float rsquared = Mathf.Pow (objdistance.magnitude, 2f);
		float Pull = thisForce * ((obj.Mass * mass) / rsquared);
		//print("pull " + Pull);

		suction = Pull * objdistance.normalized;
		//print ("suction " + suction);
			obj.Addforce (suction);
	}
}
