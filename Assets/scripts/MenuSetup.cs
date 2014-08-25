using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSetup : MonoBehaviour {
	
	public Slider soundSlider;
	public Slider musicSlider;
	public Slider fovSlider;
	public Slider sensitivitySlider;

	// Use this for initialization
	void Start () {
		soundSlider.value = PrefsManager.getSoundVolume();
		musicSlider.value = PrefsManager.getMusicVolume();
		fovSlider.value = PrefsManager.getFOV();
		sensitivitySlider.value = PrefsManager.getMouseSensitivity();
	}
}
