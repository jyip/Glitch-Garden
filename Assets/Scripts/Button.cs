using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private static Button[] buttonArray;
	private Text costText;

	// Use this for initialization
	void Start () {
		if(buttonArray == null) {
			buttonArray = GameObject.FindObjectsOfType<Button>();
		}

		foreach(Transform objTransform in transform) {
			costText = objTransform.gameObject.GetComponent<Text>();

			if(costText) {
				costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
				break;
			} else {
				Debug.LogWarning(name + "button has no cost text found!");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		foreach(Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab; 
	}

	// clean up static class references
	void OnDestroy() {
		buttonArray = null;
	}
}
