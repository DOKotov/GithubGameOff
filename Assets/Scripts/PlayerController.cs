using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	private bool facingRight = true;
	public Animator anim;

	public bool blockInput;

	[Range(-1, 1)] public float hAxis;
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		
	}

	public void ChangeState(int value)
	{
		anim.SetInteger("State", value);
	}

	void FixedUpdate()
	{
		if (!blockInput)
		{
			float move = Input.GetAxis("Horizontal");
			rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
			if (move > 0 && !facingRight)
				Flip();
			else if (move < 0 && facingRight)
				Flip();

			anim.SetFloat("hSpeed", Mathf.Abs(move));
		}
		else
		{
			rb2d.velocity = new Vector2(hAxis * speed, rb2d.velocity.y);
			if (hAxis > 0 && !facingRight)
				Flip();
			else if (hAxis < 0 && facingRight)
				Flip();

			anim.SetFloat("hSpeed", Mathf.Abs(hAxis));
		}
	}


	private void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void ActivateInput()
	{
		blockInput = false;
		print("Olololo");
	}

	public void DisactivateInput()
	{
		blockInput = true;
	}
	
	public void ActivateInputDelay(float delay)
	{
		StartCoroutine(ChangeStateInput(delay, false));
	}

	public void DisactivateInputDelay(float delay)
	{
		StartCoroutine(ChangeStateInput(delay, true));
	}

	public void SetAxisX(float value)
	{
		if (value >= 1)
			hAxis = 1;
		else if (value <= -1)
			hAxis = -1;
		else
			hAxis = value;
	}

	IEnumerator ChangeStateInput(float time, bool value)
	{
		yield return new WaitForSeconds(time);
		blockInput = value;
	}

	public void SetSpeed(float value)
	{
		speed = value;
	}
}
