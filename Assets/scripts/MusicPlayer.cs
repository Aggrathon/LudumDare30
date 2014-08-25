using UnityEngine;
using System.Collections;

[RequireComponent ( typeof(AudioSource) )]
public class MusicPlayer : MonoBehaviour {

	public AudioClip[] musicTracks = new AudioClip[0];

	AudioSource au;

	int lastPlayedIndex = -1;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		if(musicTracks.Length == 0) {
			gameObject.SetActive(false);
			Debug.LogWarning("No music added");
		}
		au = GetComponent<AudioSource>();
		au.volume = PrefsManager.getMusicVolume();
		shuffle ();
	}

	void shuffle() {
		if(musicTracks.Length < 2)
			return;
		for(int i = 0; i < musicTracks.Length; i++) {
			int i1 = Random.Range(0, musicTracks.Length);
			AudioClip m1 = musicTracks[i1];
			int i2 = Random.Range(0, musicTracks.Length);
			AudioClip m2 = musicTracks[i2];
			musicTracks[i1] = m2;
			musicTracks[i2] = m1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!au.isPlaying)
			play();
	}

	void play() {
		lastPlayedIndex++;
		if(lastPlayedIndex == musicTracks.Length)
			lastPlayedIndex = 0;
		au.clip = musicTracks[lastPlayedIndex];
		au.PlayDelayed( 1f );
	}
}
