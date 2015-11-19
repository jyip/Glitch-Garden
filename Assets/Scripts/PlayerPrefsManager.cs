using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_UNLOCKED_KEY = "level_unlocked_";

    public static void setMasterVolume(float volume){
        if(volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Volume out of range!");
        }
    }

    public static float getMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

	public static void unlockLevel(int level) {
		if(level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt(LEVEL_UNLOCKED_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Level not in build order!");
		}
	}

	public static bool isLevelUnlocked(int level) {
		if(level <= Application.levelCount - 1) {
			int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCKED_KEY + level.ToString());
			bool isLevelUnlocked = (levelValue == 1);

			return isLevelUnlocked;
		} else {
			Debug.LogError("Trying to query level not in build order!");
			return false;
		}
	}

	public static void setDifficulty(float difficulty){
		if(difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range!");
		}
	}

	public static float getDifficulty() {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
