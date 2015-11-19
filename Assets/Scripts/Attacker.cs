using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)]
	public float currentSpeed;
	private Animator animator;
	private GameObject currentObject;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

		if(!currentObject) {
			animator.SetBool("isAttacking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D obj) {
		//Debug.Log(name + " trigger enter");
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	// called from animation on dealing blow frame	
	public void StrikeCurrentTarget(float damage) {
		if(!currentObject) return;

		Health health = currentObject.GetComponent<Health>();
		health.dealDamage(damage);

		//Debug.Log(name + " is dealing "+ damage + " damage!");
	}

	public void Attack(GameObject obj) {
		currentObject = obj;
	}
}
