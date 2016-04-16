using UnityEngine;
using System.Collections;

public class PlayerShift : MonoBehaviour {

	private Animator anim;
	private PlayerMovement movement;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		movement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1"))
		{
			anim.SetLayerWeight(1, 1.0f);
			movement.blockMovement = true;
		}
		else
		{
			anim.SetLayerWeight(1, 0.0f);
			movement.blockMovement = true;
		}
	}
}
