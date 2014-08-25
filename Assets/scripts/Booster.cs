using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Booster : MonoBehaviour {

	public float boostStrength = 25000;

	public string boostAxis = "Vertical";
	Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float mod = Mathf.Clamp(Input.GetAxis(boostAxis), 0, 1)* boostStrength*Time.fixedDeltaTime;
		body.AddForce(transform.forward*mod);
	}
	
}
