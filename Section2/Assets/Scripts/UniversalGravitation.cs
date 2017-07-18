using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour {

	private PhysicsEngine[] PhysObjects;

	private const float bigG = 6.673e-11f;

	// Use this for initialization
	void Start () {
		PhysObjects = GameObject.FindObjectsOfType<PhysicsEngine>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CalculateGravity ();
	}

	void CalculateGravity ()
	{	
		foreach (PhysicsEngine physA in PhysObjects) {
			foreach (PhysicsEngine physB in PhysObjects) {
				if(physA != physB && physA != this){
					Vector3 offset = physA.transform.position - physB.transform.position;
					float rSquared = Mathf.Pow(offset.magnitude, 2f);
					float bigF = bigG * ((physA.mass * physB.mass) / rSquared);
					Vector3 gravityFeltVector = bigF * offset.normalized;

					physA.AddForces(-gravityFeltVector);
				}

			}
		}
	}
}
