using UnityEngine;
using System.Collections;

[RequireComponent ( typeof (AudioSource) )]
public class BoostSound : MonoBehaviour {

	AudioSource audioSource;

	public void setVolume (float vol) { volumeMod = vol; }
	float volumeMod = 1;

	public float lowLevel = 0.1f;
	public float sourceLevel1 = 0.3f;
	public float sourceLevel2 = 0.5f;
	public string sourceAxis1 = "Horizontal";
	public string sourceAxis2 = "Vertical";
	public bool invertInput1 = false;
	public bool invertInput2 = false;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		volumeMod = PrefsManager.getSoundVolume();
	}
	
	// Update is called once per frame
	void Update () {
		float volume = lowLevel;
		
		if (invertInput1)
			volume += Mathf.Clamp(-Input.GetAxis(sourceAxis1), 0, 1)*sourceLevel1 ;
		else
			volume += Mathf.Clamp(Input.GetAxis(sourceAxis1), 0, 1)*sourceLevel1 ;
		
		if (invertInput2)
			volume += Mathf.Clamp(-Input.GetAxis(sourceAxis2), 0, 1)*sourceLevel2 ;
		else
			volume += Mathf.Clamp(Input.GetAxis(sourceAxis2), 0, 1)*sourceLevel2 ;

		audioSource.volume = volume*volumeMod;
	}
}
