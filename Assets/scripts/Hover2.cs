using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Hover2 : MonoBehaviour {
	
	public float hoverHeight = 3;
	public float hoverStrength = 15;
	public float stabilizeStrength = 10;

	public float front = 2;
	public float left = 2;
	public float right = 2;
	public float back = 2;
	
	Vector3 leftTop() { return transform.forward*front-transform.right*left; }
	Vector3 rightTop() { return transform.forward*front+transform.right*right; }
	Vector3 leftBottom() { return -transform.forward*back-transform.right*left; }
	Vector3 rightBottom() { return -transform.forward*back+transform.right*right; }

	Rigidbody body;
	Vector3 oldHover = Vector3.zero;
	Vector3 up = Vector3.up;
	
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
		float LTdistanceToGround = hoverHeight+hoverHeight;
		if (Physics.Raycast(transform.position+leftTop(), Vector3.down, out hit, hoverHeight+hoverHeight))
			LTdistanceToGround = hit.distance;

		float RTdistanceToGround = hoverHeight+hoverHeight;
		if (Physics.Raycast(transform.position+rightTop(), Vector3.down, out hit, hoverHeight+hoverHeight))
			RTdistanceToGround = hit.distance;

		float LBdistanceToGround = hoverHeight+hoverHeight;
		if (Physics.Raycast(transform.position+leftBottom(), Vector3.down, out hit, hoverHeight+hoverHeight))
			LBdistanceToGround = hit.distance;

		float RBdistanceToGround = hoverHeight+hoverHeight;
		if (Physics.Raycast(transform.position+rightBottom(), Vector3.down, out hit, hoverHeight+hoverHeight))
			RBdistanceToGround = hit.distance;

		float distanceToGround = (LTdistanceToGround+RTdistanceToGround+LBdistanceToGround+RBdistanceToGround)/4;

		//HOVER
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

		//STABILIZE
		float hfront = (LTdistanceToGround+RTdistanceToGround)/2-distanceToGround;
		float hback = (LBdistanceToGround+RBdistanceToGround)/2-distanceToGround;
		float hright = (RTdistanceToGround+RBdistanceToGround)/2-distanceToGround;
		float hleft = (LTdistanceToGround+LBdistanceToGround)/2-distanceToGround;
		Vector3 LR = new Vector3(0,(hleft-hright),left+right);
		Vector3 TB = new Vector3(front+back,(hback-hfront),0);		
		up = Vector3.Cross(LR,TB).normalized;
		transform.up = ( transform.up + up*Time.fixedDeltaTime*stabilizeStrength/100 ).normalized;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere( (transform.position+leftTop()), 0.1f);
		Gizmos.DrawSphere( (transform.position+rightTop()), 0.1f);
		Gizmos.DrawSphere( (transform.position+leftBottom()), 0.1f);
		Gizmos.DrawSphere( (transform.position+rightBottom()), 0.1f);
		Gizmos.color = Color.red;
		Gizmos.DrawLine( transform.position+transform.right*0.01f, transform.position+up );
		Gizmos.DrawLine( transform.position+transform.forward*0.01f, transform.position+up );
		Gizmos.DrawLine( transform.position-transform.right*0.01f, transform.position+up );
	}
}
