using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedForce : MonoBehaviour {

	private Vector3 vectorForce;

	// Use this for initialization
	void Start () {
		vectorForce = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 forces ()
	{
		return vectorForce;
	}
}
