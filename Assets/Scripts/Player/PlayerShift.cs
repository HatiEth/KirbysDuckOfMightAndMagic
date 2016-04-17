using UnityEngine;
using System.Collections;

public class PlayerShift : MonoBehaviour {

	private PlayerShiftModel model;

	// Use this for initialization
	void Start () {
		model = GetComponent<PlayerShiftModel>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Fire1"))
		{
			model.NextState (PlayerShiftModel.State.Sword);
		}
		else if (Input.GetButton ("Fire2"))
		{
			model.NextState (PlayerShiftModel.State.Shield);
		}
		else if (Input.GetButton ("Fire3"))
		{
			model.NextState (PlayerShiftModel.State.Bow);
		} 
		else
		{
			model.NextState (PlayerShiftModel.State.Default);
		}

	}
}
