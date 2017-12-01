using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// roboDash follow script
[RequireComponent(typeof(Rigidbody2D))]
public class FollowScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;

    public float speed = 10f;
    public float offset = 5f;

    public bool follow;

    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (follow && Vector2.Distance(target.position, transform.position) > offset)
        {
            Vector2 delta = (target.position - transform.position).normalized;
            rb.velocity = delta * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if(follow)
            transform.localScale = target.position.x > transform.position.x ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

        if (anim != null)
            anim.SetFloat("hSpeed", Mathf.Abs(rb.velocity.x));
    }

    public void SetFollow(bool value)
    {
        follow = value;
    }

    public void SetOffset(float value)
    {
        offset = value;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}