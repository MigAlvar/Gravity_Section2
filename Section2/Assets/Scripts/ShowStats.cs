using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShowStats : MonoBehaviour {

	private Rigidbody body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(body.inertiaTensor);
		Debug.Log(body.centerOfMass);
	}
}
