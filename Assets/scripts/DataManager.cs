using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {
	bool initialized = false;

	void Awake() {
		if(!initialized) {
			PrefsManager.loadPrefs();
			initialized = true;
		}
		DontDestroyOnLoad(gameObject);
	}

	void OnDestroy() {
		PrefsManager.savePrefs();
	}
}
