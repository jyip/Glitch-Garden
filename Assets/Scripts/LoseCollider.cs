using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	[Tooltip("Number of enemies crossed before player loses!")]
	public int crossPoints;

	private LevelManager levelManager;
	private int crossPointsCounter = 0;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D() {
		if(crossPointsCounter >= crossPoints) {
			levelManager.LoadLevel("03b Lose");
		} else {
			crossPointsCounter++;
		}
	}
}
