using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost = 100;

	private static StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		if(starDisplay == null) {
			starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStars() {
		int starsToAdd = gameObject.GetComponent<StarTrophy>().starsProduced;
		starDisplay.AddStars(starsToAdd);
	}
}
