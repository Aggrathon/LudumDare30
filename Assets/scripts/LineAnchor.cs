using UnityEngine;
using System.Collections;

[RequireComponent ( typeof ( LineRenderer))]
public class LineAnchor : MonoBehaviour {

	public Transform connectedTransform;
	public Vector3 offset;

	LineRenderer lr;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = connectedTransform.position+ connectedTransform.rotation * offset;
		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, pos);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.gray;
		Gizmos.DrawSphere(connectedTransform.position+ connectedTransform.rotation * offset, 0.05f);
		Gizmos.DrawSphere(transform.position, 0.05f);
		Gizmos.DrawLine(transform.position, connectedTransform.position+ connectedTransform.rotation * offset);
	}
}
