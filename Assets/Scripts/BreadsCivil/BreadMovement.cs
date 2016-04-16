using UnityEngine;
using System.Collections;

public class BreadMovement : MonoBehaviour {


	public float Speed = 1f;
	public bool moveByForce = false;
	public float forceMultiplier = 1f;

	Vector3 movement;

	Animator anim;
	new Rigidbody rigidbody;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}

	public void Move(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		//anim.SetFloat ("fSpeed", Mathf.Abs(h)+Mathf.Abs(v));
		anim.SetBool("bWalk", walking);
		anim.SetFloat("fSpeedX", h);
		anim.SetFloat("fSpeedY", v);
		if(h != 0)
		{
				sprite.flipX = h < 0;
		}

		movement.Set (h, 0f, v);
		movement = movement.normalized * Speed * Time.deltaTime;

		if (!moveByForce)
			rigidbody.MovePosition (transform.position + movement); //current pos + movement
		else
			rigidbody.AddForce (movement * forceMultiplier);
	}
}
