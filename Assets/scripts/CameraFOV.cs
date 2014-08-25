using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class CameraFOV : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Camera>().fieldOfView = PrefsManager.getFOV();
	}
}
