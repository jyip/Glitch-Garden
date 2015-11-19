using UnityEngine;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	public float damage;
	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;
		
		if (!obj.GetComponent<Defender>()) return;

		animator.SetBool("isAttacking", true);
		attacker.Attack(obj);
	}

	public void onStrike() {
		attacker.StrikeCurrentTarget(damage);
	}
}
