using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// roboDash follow script

public class FollowScript : MonoBehaviour {


	public Transform target;
	Rigidbody2D rb;

	public float speed = 10f;
	public float offset = 5f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	void Update() {
		if (Vector2.Distance (target.position, transform.position) > offset) {
			Vector2 delta = (target.position - transform.position).normalized;
			rb.velocity = delta * speed;
		}
	}


}
	