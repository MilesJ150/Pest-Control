using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VelocityReporter : MonoBehaviour {
	private Vector3 prevPos;
	public Vector3 velocity
	{
		get;
		private set;
	}
	public Vector3 prevVelocity
	{
		get;
		private set;
	}
	// Use this for initialization
	void Start () {
		prevPos = this.transform.position;
	}
	// Update is called once per frame
	void Update () {
		velocity = (this.transform.position - prevPos) / Time.deltaTime;
		if (Vector3.Magnitude(velocity) > 0.2f) {
			prevVelocity = velocity;
		}
		prevPos = this.transform.position;
	}
}
