using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] LevelMusicChangerArray;
    private AudioSource audio;

    void Awake() {
        DontDestroyOnLoad(gameObject);
		Debug.Log("Setting persistent Music Manager");
    }

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
		float playerVolume = PlayerPrefsManager.getMasterVolume();
		setVolume(playerVolume);
		//Debug.Log("Setting Music Manager audio source");
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded(int level) {
        AudioClip currentMusicClip = LevelMusicChangerArray[level];
        if(currentMusicClip) {
            audio.clip = currentMusicClip;
            audio.loop = true;
            audio.Play();
        }
    }

	public void setVolume(float volume) {
		audio.volume = volume;
	}
}
