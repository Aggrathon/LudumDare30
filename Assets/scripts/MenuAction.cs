using UnityEngine;
using System.Collections;

public class MenuAction : MonoBehaviour {

	public float rotationSpeed = 10f;
	public Transform rotator;
	public Transform floater;
	public float minFloatHeight = 1f;
	public float maxFloatHeight = 5f;
	public float floatSpeed = 10f;

	bool FloatUp = true;
	
	// Update is called once per frame
	void Update () {
		rotator.Rotate(Vector3.up*rotationSpeed*Time.deltaTime);
	}

	void FixedUpdate() {
		if(floater.position.y > maxFloatHeight-0.1)
			FloatUp = false;
		if(floater.position.y < minFloatHeight+0.1)
			FloatUp = true;

		if(FloatUp)
			floater.position = new Vector3(floater.position.x, floater.position.y+floatSpeed/10*Time.fixedDeltaTime, floater.position.z);
		else
			floater.position = new Vector3(floater.position.x, floater.position.y-floatSpeed/10*Time.fixedDeltaTime, floater.position.z);
	}

	public void quitGame() {
		Application.Quit();
	}
	public void playGame() {
		Application.LoadLevel("TrainingCanyon");
	}
	
	public void setSoundVolume (float volume) {
		PrefsManager.setSoundVolume(volume);
		AudioSource au;
		BoostSound bs;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("soundSource")) {
			if( (au = go.GetComponent<AudioSource>()) != null)
				au.volume = volume;
			if( (bs = go.GetComponent<BoostSound>()) != null)
				bs.setVolume(volume);
		}
	}
	public void setMusicVolume (float volume) {
		PrefsManager.setMusicVolume(volume);
		AudioSource au;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("musicSource"))
			if( (au = go.GetComponent<AudioSource>()) != null)
				au.volume = volume;
	}
	public void setFOV (float fov) {
		PrefsManager.setFOV(fov);
	}
	public void setMouseSensitivity (float ms) {
		PrefsManager.setMouseSensitivity(ms);
	}
}
