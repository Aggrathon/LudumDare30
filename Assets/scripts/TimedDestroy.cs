using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {
	public float delay = 10;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, delay);	
	}
}
