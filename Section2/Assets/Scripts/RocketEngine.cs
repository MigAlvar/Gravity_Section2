using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEngine : MonoBehaviour {

	public float fuelMass;				//[kg]
	public float maxThrust;				//kN [kg m s^-2]
	[Range(0,1)]
	public float thrustPercent;			
	public Vector3 thrustUnitVector;	//[m s^-1]
	public float currentThrust;

	private PhysicsEngine Engine;

	// Use this for initialization
	void Start () {
		Engine = GetComponent<PhysicsEngine>();
		Engine.mass += fuelMass;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		if (fuelMass > FuelThisUpdate ()) {
			fuelMass -= FuelThisUpdate ();
			Engine.mass -= FuelThisUpdate ();
			ExertForce();
		}else{
			Debug.LogWarning("Out of Fuel");
		}
	}

	float FuelThisUpdate ()
	{
		float exhaustMassFlow;
		float effectiveExhaustVelocity;

		effectiveExhaustVelocity = 4462f;
		exhaustMassFlow = currentThrust / effectiveExhaustVelocity;

		return exhaustMassFlow * Time.deltaTime;
	}

	void ExertForce(){
		currentThrust = thrustPercent * maxThrust * 1000f;
		Vector3 thrustVector = thrustUnitVector.normalized * currentThrust;
		Engine.AddForces(thrustVector);
	}

	public Vector3 forces ()
	{
		return thrustUnitVector;
	}
}
