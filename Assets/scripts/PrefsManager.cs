using UnityEngine;

public class PrefsManager {
	private const string SOUND_VOLUME = "soundVolume";
	private const string MUSIC_VOLUME = "musicVolume";
	private const string FOV_VALUE = "fovValue";
	private const string MOUSE_SENSITIVITY = "mouseSensitivity";
	
	private static float soundVolume = 1f;
	private static float musicVolume = 1f;
	private static float fovValue = 60f;
	private static float mouseSensitivity = 15f;

	public static void savePrefs() {
		PlayerPrefs.SetFloat(SOUND_VOLUME, soundVolume);
		PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
		PlayerPrefs.SetFloat(FOV_VALUE, fovValue);
		PlayerPrefs.SetFloat(MOUSE_SENSITIVITY, mouseSensitivity);
		PlayerPrefs.Save();
	}
	public static void loadPrefs() {
		soundVolume = PlayerPrefs.GetFloat(SOUND_VOLUME, soundVolume);
		musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME, musicVolume);
		fovValue = PlayerPrefs.GetFloat(FOV_VALUE, fovValue);
		mouseSensitivity = PlayerPrefs.GetFloat(MOUSE_SENSITIVITY, mouseSensitivity);
	}

	public static void setSoundVolume(float vol) {
		soundVolume = vol;
	}	
	public static void setMusicVolume(float vol) {
		musicVolume = vol;
	}
	public static void setFOV (float fov) {
		fovValue = fov;
	}
	public static void setMouseSensitivity (float ms) {
		mouseSensitivity = ms;
	}
	
	public static float getSoundVolume() {
		return soundVolume;
	}
	public static float getMusicVolume() {
		return musicVolume;
	}
	public static float getFOV() {
		return fovValue;
	}
	public static float getMouseSensitivity() {
		return mouseSensitivity;
	}
}
