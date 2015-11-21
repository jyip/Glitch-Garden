using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text display;
	private int totalStars = 100;

	public enum Status {SUCCESS, FAIL};

	// Use this for initialization
	void Start () {
		display = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddStars(int stars) {
		totalStars += stars;
		UpdateDisplay();
	}

	public Status UseStars(int stars) {
		if(totalStars < stars) return Status.FAIL;

		totalStars -= stars;
		if(totalStars < 0) {
			totalStars = 0;
		}
		UpdateDisplay();

		return Status.SUCCESS;
	}

	private void UpdateDisplay() {
		display.text = totalStars.ToString();
	}
}
