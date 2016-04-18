using UnityEngine;
using System.Collections;

public class BreadKnightMovement : MonoBehaviour{

	Animator anim;
	SpriteRenderer sprite;

	public BreadKnightWeapon Weapon;
	private StaminaResource Stamina;


	// Use this for initialization
	protected	void Start () {
		var SpriteObj = transform.FindChild("BreadKnightSprite");
		anim = SpriteObj.GetComponent<Animator>();
		sprite = SpriteObj.GetComponent<SpriteRenderer>();
		Stamina = GetComponent<StaminaResource>();
	}

	public void Move(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("bWalk", walking);
		anim.SetFloat("fSpeedX", h, 0.1f, Time.deltaTime);
		anim.SetFloat("fSpeedY", v, 0.1f, Time.deltaTime);
		if(h != 0)
		{
				//sprite.flipX = h < 0;
		}
	}
	void Update()
	{
		/*
		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			Attack((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized);
		}
		*/
	}

	public void Attack(Vector3 dir)
	{
		dir.y = 0f;
		Weapon.transform.forward = dir;

		if(Stamina.Current >= Weapon.StaminaUsage)
		{
			if (Weapon.Fire())
			{
				Stamina.Use(Weapon.StaminaUsage);
			};
		}

	}
}
