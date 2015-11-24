using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private GameObject PlayerOne;
	private GameObject PlayerTwo;
	private GameObject activePersona;
	private GameObject[] trackedGamePieces;
	private GameObject[] highlightGrids;

	// Use this for initialization
	void Start ()
	{
		trackedGamePieces = GameObject.FindObjectsOfType<Persona>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown() {
		if (!activePersona && setActivePersona()) {
			clearHighlightGrids();
			highlightPossibleMoveGrids();
		} else if (activePersona) {
			Vector2 targetGridPoint = getSnappedWorldPointOfMouseClick();

			// set active persona target move point

		}
	}

	void clearHighlightGrids() {
		foreach (GameObject highlightGrid in highlightGrids) {
			Destroy(highlightGrid);
		}
	}

	void highlightPossibleMoveGrids() {
		if (!activePersona) {
			Debug.LogWarning("No active persona!");
		}

		int movePoints = activePersona.movePoints;
		int firstPoint = 1;
		int lastPoint = 9;
		Vector2 startPosition = activePersona.position;

		for(int x = firstPoint;x <= lastPoint; x++) {
			for(int y = firstPoint; y <= lastPoint; y++) {
				int movePointsUsed = 0;

				int xPoints = startPosition.x - x;
				int yPoints = startPosition.y - y;

				movePointsUsed = Math.Abs(xPoints) + Math.A
			}
		}
	}

	bool setActivePersona() {
		Vector2 targetGridPoint = getSnappedWorldPointOfMouseClick();

		foreach (GameObject mapObject in trackedGamePieces) {
			if(mapObject.transform.position == targetGridPoint) {
				activePersona = mapObject;
				return true;
				break;
			}
		}

		return false;
	}

	Vector2 getSnappedWorldPointOfMouseClick() {
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int pointX = Mathf.RoundToInt(worldPoint.x);
		int pointY = Mathf.RoundToInt(worldPoint.y);
		return new Vector2(pointX, pointY);
	}
}

