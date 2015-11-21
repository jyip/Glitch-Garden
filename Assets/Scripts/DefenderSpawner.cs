using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private static GameObject parent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find("Defenders");
		if(parent == null) {
			parent = new GameObject("Defenders");
		}

		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	// Update is called once per frame
	void Update () {
	
	}

	bool payCost() {
		Defender defender = Button.selectedDefender.GetComponent<Defender>();
		StarDisplay.Status result = starDisplay.UseStars(defender.starCost);

		if(result == StarDisplay.Status.FAIL) {
			Debug.Log("Not enough stars!");
			return false;
		} else if (result == StarDisplay.Status.SUCCESS) {
			return true;
		}

		return false;
	}

	void OnMouseDown() {
		// pay cost
		if(!payCost()) return;

		// spawn defender
		GameObject newDefender = Instantiate(Button.selectedDefender);
		newDefender.transform.position = getSnappedWorldPointOfMouseClick();
		newDefender.transform.parent = parent.transform;
	}

	Vector2 getSnappedWorldPointOfMouseClick() {
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int pointX = Mathf.RoundToInt(worldPoint.x);
		int pointY = Mathf.RoundToInt(worldPoint.y);
		return new Vector2(pointX, pointY);
	}
}
