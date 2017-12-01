using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEyes : MonoBehaviour {

	private Transform target;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			target = other.transform;
			foreach (Transform child in transform) {
				var script = child.GetComponent<FollowScript> ();
				script.target = target;
				script.follow = true;
			}
		}
	}
}
