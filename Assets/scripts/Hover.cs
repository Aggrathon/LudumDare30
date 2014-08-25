using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Hover : MonoBehaviour {
	
	public float hoverHeight = 2;
	public float hoverStrength = 10;

	Rigidbody body;
	Vector3 oldHover = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hover ();
	}
	
	void hover() {
		RaycastHit hit;
		float distanceToGround = hoverHeight+hoverHeight;
		if (Physics.Raycast(transform.position, Vector3.down, out hit, hoverHeight+hoverHeight))
			distanceToGround = hit.distance;
		
		if(distanceToGround < hoverHeight) {
			float modifier = (hoverHeight-distanceToGround)/hoverHeight*hoverStrength;
			Vector3 newHover = Vector3.up*modifier;
			body.velocity =  body.velocity-oldHover+newHover;
			oldHover = newHover;
		} else {
			float modifier = Mathf.Clamp(distanceToGround-hoverHeight, 0, hoverHeight)/hoverHeight*hoverStrength;
			Vector3 newHover = Vector3.down*modifier;
			body.velocity =  body.velocity-oldHover+newHover;
			oldHover = newHover;
		}
	}
}
