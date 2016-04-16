using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	private ProjectileWeapon _projectileThis;

	// Use this for initialization
	void Start () 
	{
		_projectileThis = GetComponent<ProjectileWeapon> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire")) 
		{
			_projectileThis.Fire ();
		}
	}
}
