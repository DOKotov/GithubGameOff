﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// roboDash follow script

public class FollowScript : MonoBehaviour {


	public Transform target;
	public Transform LBorder;
	public Transform RBorder;
	
	Rigidbody2D rb;

	private Animator anim;

	public float speed = 10f;
	public float offset = 5f;

	public bool follow;

	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	void Update() {
		if (Vector2.Distance(target.position, transform.position) > offset && follow)
		{
			Vector2 delta = (target.position - transform.position).normalized;
			rb.velocity = delta * speed;
		}
	}
	public void SetFollow()
	{
			follow = !follow;
	}

	private bool Follow()
	{
		var outSide = Vector2.Distance(target.position, transform.position) > offset;

		return false;
	}
	private bool Righter(Transform targetTransform, float epsilonDistance)
	{
		return !(transform.position.x < targetTransform.position.x + epsilonDistance);
	}
	private bool Lefter(Transform targetTransform, float epsilonDistance)
	{
		return transform.position.x > targetTransform.position.x - epsilonDistance;
	}
}
	