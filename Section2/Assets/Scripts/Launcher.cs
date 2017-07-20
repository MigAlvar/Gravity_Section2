using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	public GameObject Ball;
	public float maxStrength;
	public AudioClip[] Sfx;

	private float holdTime;
	private AudioSource Snd;
	private float extraSpeedPerFrame;
	// Use this for initialization
	void Start () {
		Snd = GetComponent<AudioSource>();
		extraSpeedPerFrame = (maxStrength* Time.fixedDeltaTime)/Sfx[0].length;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Pull();
		}
		if(Input.GetMouseButtonUp(0)){
			MouseUp();
		}
	}

	void Pull(){

		holdTime = 0;
		Snd.PlayOneShot(Sfx[0]);
		InvokeRepeating("increaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
	}

	void MouseUp ()
	{
		CancelInvoke();
		Snd.Stop();
		Snd.PlayOneShot(Sfx[1]);
		GameObject ball = Instantiate(Ball) as GameObject;
		ball.transform.position = transform.position;
		Vector3 ThrustVector = new Vector3 (1,1,0) * maxStrength;
		ball.GetComponent<PhysicsEngine>().velocityVector = ThrustVector;
	}

	void increaseLaunchSpeed ()
	{
		if (holdTime < maxStrength) {
			holdTime += extraSpeedPerFrame;
		}

	}
}
