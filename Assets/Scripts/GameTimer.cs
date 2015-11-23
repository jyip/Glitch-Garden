using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	[Tooltip ("duration in seconds")]
	public int levelDuration;
	public AudioClip victoryAudioClip;

	private Slider timerSlider;
	private LevelManager levelManager;
	private GameObject victoryPopup;
	private bool levelHasEnded = false;

	// Use this for initialization
	void Start () {
		timerSlider = GetComponent<Slider>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		victoryPopup = GameObject.Find("Victory Popup");
		victoryPopup.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!levelHasEnded && Time.timeSinceLevelLoad >= levelDuration) {
			// victory
			levelHasEnded = true;

			// show popup
			victoryPopup.SetActive(true);
			victoryPopup.GetComponent<Text>().text = "Victory!";

			// play sound
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = victoryAudioClip;
			audio.volume = PlayerPrefsManager.getMasterVolume();
			audio.Play();

			// change to win screen
			Invoke("LoadNextLevel", audio.clip.length);
		} else {
			timerSlider.value = Time.timeSinceLevelLoad / levelDuration;
		}
	}

	void LoadNextLevel() {
		levelManager.LoadLevel("03a Win");
	}
}
