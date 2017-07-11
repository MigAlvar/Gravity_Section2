using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEngine : MonoBehaviour {


	public float fuelMass;				//[kg]
	public float maxThrust;				//kN [kg m s^-2]
	public float thrustPercent;			
	public Vector3 thrustUnitVector;	//[m s^-1]

	private PhysicsEngine Engine;

	// Use this for initialization
	void Start () {
		Engine = GetComponent<PhysicsEngine>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Engine.AddForces(thrustUnitVector);
	}

	public Vector3 forces ()
	{
		return thrustUnitVector;
	}
}
