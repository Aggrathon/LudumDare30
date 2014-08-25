using UnityEngine;
using System.Collections;

[ RequireComponent ( typeof ( AudioSource ) ) ]
public class SoundPrefVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().volume = PrefsManager.getSoundVolume();
	}
}
