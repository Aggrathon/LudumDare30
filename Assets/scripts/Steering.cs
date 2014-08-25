using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Steering : MonoBehaviour {
	
	public float boostStrength = 10000;
	public string boostAxis = "Horizontal";

	public Transform leftThruster;
	public Transform rightThruster;


	Rigidbody body;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float input = Input.GetAxis(boostAxis);
		float mod = boostStrength*Time.fixedDeltaTime;
		body.AddForceAtPosition(transform.forward*mod*Mathf.Clamp(input, 0, 1), leftThruster.position);
		body.AddForceAtPosition(transform.forward*mod*Mathf.Clamp(-input, 0, 1), rightThruster.position);
	}
	
}
