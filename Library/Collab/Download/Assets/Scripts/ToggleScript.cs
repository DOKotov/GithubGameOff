using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour {
	public FollowScript follower;
	public bool value;

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player"))
			follower.SetFollow (value);
	}
}
