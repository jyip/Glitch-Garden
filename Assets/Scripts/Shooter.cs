using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private static GameObject projectileParent;
	private static GameObject spawners;

	private GameObject laneSpawner;
	private Animator animator;

	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find("Projectiles");
		if(projectileParent == null) {
			projectileParent = new GameObject("Projectiles");
		}

		if(spawners == null) {
			spawners = GameObject.Find("Spawners");
		} else {
			Debug.LogWarning("No spawners object found!");
		}

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAttackerAheadInLane()) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}

	private GameObject findSpawner() {
		GameObject targetSpawner = null;

		foreach(Transform spawnerTransform in spawners.transform) {
			if(spawnerTransform.position.y == gameObject.transform.position.y) {
				targetSpawner = spawnerTransform.gameObject;
				break;
			}
		}
		
		if(targetSpawner == null) {
			Debug.LogWarning("No spawner found for attacker!");
		}

		return targetSpawner;
	}

	private bool IsAttackerAheadInLane() {
		// find spawner
		if(laneSpawner == null) {
			laneSpawner = findSpawner();
		}

		// determine if x position is ahead of shooter
		if(laneSpawner.transform.childCount == 0) return false;

		foreach(Transform attackerTransform in laneSpawner.transform) {
			if(attackerTransform.position.x > gameObject.transform.position.x) {
				return true;
			}
		}

		return false;
	}

	private void FireGun() {
		GameObject currentProjectile = Instantiate(projectile) as GameObject;
		currentProjectile.transform.parent = projectileParent.transform;
		currentProjectile.transform.position = gun.transform.position;
	}
}
