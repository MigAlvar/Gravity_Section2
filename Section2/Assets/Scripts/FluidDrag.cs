using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour {

[Range(1, 2f)]
public float velocityExponent;
public float dragConstant;

private PhysicsEngine Engine;

	// Use this for initialization
	void Start () {
		Engine = GetComponent<PhysicsEngine>();
	}
	
	void FixedUpdate(){
		Vector3 velocityVector = Engine.velocityVector;
		float speed = velocityVector.magnitude;
		float dragSize = CalculateDrag(speed);
		Vector3 dragVector = dragSize * -velocityVector.normalized;

		Engine.AddForces(dragVector);
	}

	float CalculateDrag(float speed) {
		return dragConstant * Mathf.Pow(speed, velocityExponent);
	}
}
