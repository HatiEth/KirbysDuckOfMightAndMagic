using UnityEngine;
using System.Collections;

public class PlayerShift : MonoBehaviour {

	private Animator anim;
	private PlayerMovement movement;
	private PlayerShiftModel model;

	public string InputString;
	public int AnimationLayer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		movement = GetComponent<PlayerMovement>();
		model = GetComponent<PlayerShiftModel>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton(InputString))
		{
			anim.SetLayerWeight(AnimationLayer, 1.0f);
		}
		else
		{
			anim.SetLayerWeight(AnimationLayer, 0.0f);
		}
	}
}
