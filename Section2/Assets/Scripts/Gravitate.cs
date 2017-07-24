using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitate : MonoBehaviour {

	[SerializeField] private float mass = 8;
	private Vector3 vectoring;

	private bool acquired = false;
	public bool Acquired{
		get{return acquired;}
		set{acquired = value;}
	}
	public Vector3 direction {
		get {return vectoring;}
		set {vectoring = value;}
	}

	public float Mass {
		get {return mass;}
	}

	private Vector3 Netforce;
	private List <Vector3> forceListing = new List <Vector3>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		updatePosition ();
		if (!acquired) {
			transform.position += vectoring * Time.deltaTime;
		} else {
			transform.position = transform.position;
		}
	}

	public void Addforce (Vector3 DeusEx)
	{
		forceListing.Add(DeusEx);
		//print("DeusEx " + DeusEx);
	}

	void updatePosition ()
	{
		Netforce = Vector3.zero;

		foreach (Vector3 force in forceListing) {
			Netforce += force;
		}
		//print("netforce "+ Netforce);
		Vector3 accel = Netforce / mass;
		vectoring +=  accel * Time.deltaTime;
		//print("accel " + accel);
		//print("vectoring " + vectoring);

		forceListing = new List<Vector3>();
	}

	void OnTriggerEnter (Collider other)
	{
		print ("touched");
		Gravitator owner = other.GetComponent<Gravitator> ();
		if (owner) {acquired = true;}
	}
}
