using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public float walkingSpeed = 6f;
	public float dashSpeed = 36f;
	public float forceMultiplier = 10.0f;

	[HideInInspector]
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	RigidbodyConstraints originalCons;
    SpriteRenderer sprite;
	[SerializeField]
	IsoCameraController m_isocamMainCamera;

	public bool blockMovement = false;
	public bool isDashing = false;
	public bool moveByForce = false;

	bool onFloor = false;
	float fallSpeed = 800f;

	float dashH = 0f;
	float dashV = 0f;

	void Awake()
	{
		anim = transform.Find("PlayerSprite").GetComponent<Animator> ();
		sprite = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
		playerRigidbody = GetComponent<Rigidbody> ();
		originalCons = playerRigidbody.constraints;
	}

	void Start() {
		Quaternion newRotation = Quaternion.LookRotation(movement);
		//playerRigidbody.MoveRotation(newRotation);
		transform.GetChild(0).rotation = newRotation;
	}

	// physics update
	void FixedUpdate()
	{	
		playerRigidbody.constraints = originalCons;
		speed = walkingSpeed;
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if(isDashing)
		{
			speed = dashSpeed;
			h = dashH;
			v = dashV;
		}
		else
		{
			dashH = h;
			dashV = v;
		}
		
		bool walking = h != 0f || v != 0f;
		if(onFloor && !blockMovement)
		{
			Move (h, v);
			Turning (h, v, walking);
			Animating (h, v, walking);
		}
		else
		{
			Fall();
		}
	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		m_isocamMainCamera.SetDirection (movement);

		if (!moveByForce)
			playerRigidbody.MovePosition (transform.position + movement); //current pos + movement
		else
			playerRigidbody.AddForce (movement * forceMultiplier);
	}

	void Turning(float h, float v, bool isWalking)
	{
		if (isWalking)
		{
			Vector3 movement = new Vector3(h, 0.0f, v);
			Quaternion newRotation = Quaternion.LookRotation(movement);
			//playerRigidbody.MoveRotation(newRotation);
			transform.GetChild(0).rotation = newRotation;
		}
	}

	void Animating (float h, float v, bool walking)
	{
        //anim.SetFloat ("fSpeed", Mathf.Abs(h)+Mathf.Abs(v));
        anim.SetBool("bWalk", walking);
        anim.SetFloat("fSpeedX", h);
        anim.SetFloat("fSpeedY", v);
        if(h != 0)
        {
            sprite.flipX = h > 0;
        }
	}
	
	bool getKnockdown()
	{
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(2);
		bool knockdown = info.IsName("knockdownL") || info.IsName("knockdownR");
		bool knockdownIdle = info.IsName("knockdownIdleL") || info.IsName("knockdownIdleR");
		
		return knockdown || knockdownIdle;
	}

	void OnCollisionStay(Collision col)
	{
		if(col.collider.tag == "Floor")
		{
			onFloor = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		//Debug.Log("not on:" + col.collider.tag);
		if(col.collider.tag == "Floor")
		{
			onFloor = false;
		}
	}
	
	public Vector3 getMovement()
	{
		return movement;
	}

	void Fall()
	{
		playerRigidbody.AddForce(0,-1 * fallSpeed,0);
		originalCons = playerRigidbody.constraints;
		playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
	
	public void PushByForce(float h, float v, float distance)
	{	
		movement.Set (h, 0f, v);
		movement = movement.normalized * distance * Time.deltaTime;
		playerRigidbody.AddForce (movement * forceMultiplier);
	}
}
