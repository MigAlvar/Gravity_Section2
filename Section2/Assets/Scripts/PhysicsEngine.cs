using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsEngine : MonoBehaviour {

	[Tooltip ("Kg")]
	public float mass;					
	public bool showTrails = true;
	[Tooltip ("m s^1")]
	public Vector3 velocityVector;
	[Tooltip("N [kg m s^-2]")]
	public Vector3 netForceVector;

	private List <Vector3> forceVectorList = new List <Vector3>(); 
	public List<Vector3> forceList {
		get {
			return forceVectorList;
		}
	}

	/*private Vector3[] forceVectorList;
	public Vector3[] forceList {
		get {
			return forceVectorList;
		}
	}*/

	private LineRenderer lineRenderer;
	private int numberOfForces;

	// Use this for initialization
	void Start () {
		//forceVectorList = gameObject.GetComponent<PhysicsEngine>();

		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.SetColors(Color.yellow, Color.yellow);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}
	
	// Update is called once per frame
	void Update () {
		RenderTrails();
	}

	void FixedUpdate ()
	{
		SumForces ();

		UpdateVelocity();
		//if (netForceVector == Vector3.zero) {
		transform.position += velocityVector * Time.deltaTime;
		//}else{
			
		//}
	}

	public void AddForces (Vector3 forceVector)
	{
		forceVectorList.Add(forceVector);
	}

	void SumForces ()
	{	
		netForceVector = Vector3.zero;
		foreach (Vector3 force in forceVectorList){
			netForceVector += force;
		}

		forceVectorList = new List <Vector3>();
	}

	void UpdateVelocity(){
		Vector3 accelmotion = netForceVector / mass;
		velocityVector +=  accelmotion * Time.deltaTime;
	}

	void RenderTrails(){
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.SetVertexCount(numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList) {
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		} else {
			lineRenderer.enabled = false;
		}
	}
}
