using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun, projectileParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void FireGun() {
		GameObject currentProjectile = Instantiate(projectile) as GameObject;
		currentProjectile.transform.parent = projectileParent.transform;
		currentProjectile.transform.position = gun.transform.position;
	}
}
