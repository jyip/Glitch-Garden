using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] AttackerPrefabs;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in AttackerPrefabs) {
			if(isTimeToSpawn(attacker)) {
				Spawn(attacker);
			}	
		}
	}

	private bool isTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if(Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate is capped by framerate!");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		return (Random.value < threshold);
	}

	public void Spawn(GameObject spawnObject) {
		GameObject newObject = Instantiate(spawnObject) as GameObject;
		newObject.transform.parent = transform;
		newObject.transform.position = transform.position;
	}
}
