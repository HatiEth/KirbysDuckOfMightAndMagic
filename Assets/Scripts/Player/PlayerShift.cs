using UnityEngine;
using System.Collections;

public class PlayerShift : MonoBehaviour {

	private PlayerShiftModel model;
	private PlayerMovement movement;

	// Use this for initialization
	void Start () {
		model = GetComponent<PlayerShiftModel>();
		movement = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
