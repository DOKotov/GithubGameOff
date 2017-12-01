using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	private bool facingRight = true;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();	
	}
		
	void FixedUpdate() {
		float move = Input.GetAxis("Horizontal");
		rb2d.velocity = new Vector2 (move * speed, rb2d.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}


	private void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
