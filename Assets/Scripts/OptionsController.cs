using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	const float DEFAULT_VOLUME_VALUE = 0.8f;
	const int DEFAULT_DIFFICULTY_VALUE = 2;

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.getMasterVolume();
		difficultySlider.value = PlayerPrefsManager.getDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.setVolume(volumeSlider.value);
	}

	public void saveAndExit() {
		PlayerPrefsManager.setMasterVolume(volumeSlider.value);
		PlayerPrefsManager.setDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}

	public void setDefaults() {
		volumeSlider.value = DEFAULT_VOLUME_VALUE;
		difficultySlider.value = DEFAULT_DIFFICULTY_VALUE;
	}
}
