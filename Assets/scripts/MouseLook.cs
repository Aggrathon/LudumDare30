using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	float rotationZ;
	float rotationX;
	float rotationY;
	float sensitivity;

	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		rotationX = transform.rotation.x;
		rotationY = transform.rotation.y;
		rotationZ = transform.rotation.z;
		sensitivity = PrefsManager.getMouseSensitivity();
	}
	
	// Update is called once per frame
	void Update () {		
		rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity + Input.GetAxis("Controller X")*sensitivity/15;
		rotationY += Input.GetAxis("Mouse Y") * sensitivity - Input.GetAxis("Controller Y")*sensitivity/15;
		rotationY = Mathf.Clamp (rotationY, -70F, 70F);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, rotationZ);
		
	}
}
