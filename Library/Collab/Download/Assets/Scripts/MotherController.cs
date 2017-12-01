using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	public float speed;
	private bool facingRight = true;
	public Animator anim;
	public float disabledTime;

	private SpriteRenderer _spriteRenderer;

	[Range(0, 1)] public float fadeDuration;
	
	public bool blockInput;

	[Range(-1, 1)] public float hAxis;
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		_spriteRenderer = GetComponent<SpriteRenderer>();	

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

	IEnumerator HideMomCorutine()
	{
		var finalAlpha = 0.0f;
		var fadeSpeed = Mathf.Abs(_spriteRenderer.color.a - finalAlpha) / fadeDuration;

		while (!Mathf.Approximately(_spriteRenderer.color.a, finalAlpha))
		{
			var alpha = Mathf.MoveTowards(_spriteRenderer.color.a, finalAlpha,
				fadeSpeed * Time.deltaTime);

			Color newColor = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b,
				alpha);
			_spriteRenderer.color = newColor;
			yield return null;
		}
		yield return new WaitForSeconds(disabledTime);
		gameObject.SetActive(false);
	}

	public void HideMom()
	{
		StartCoroutine(HideMomCorutine());
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
}
