using UnityEngine;
using System.Collections;

public class PlayerSwordAttack : ProjectileWeapon 
{

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		m_fShotPower = 0.0f;
		m_fDestroyDelay = 0.2f;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
