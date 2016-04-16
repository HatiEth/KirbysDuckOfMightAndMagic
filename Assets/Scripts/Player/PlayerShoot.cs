using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	private ProjectileWeapon m_projectileThis;
	private PlayerSwordAttack m_swordAttackThis;
	private PlayerBowAttack m_bowAttackThis;
	[SerializeField]
	private PlayerShiftModel m_shiftmodThis;

	private bool m_bCanShoot = true;
	private float m_fShootDelay = 0.5f;
	// Use this for initialization
	void Start () 
	{
		m_projectileThis = GetComponent<ProjectileWeapon> ();
		m_swordAttackThis = GetComponent<PlayerSwordAttack> ();
		m_bowAttackThis = GetComponent<PlayerBowAttack> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis("UseMode") > 0.5f) 
		{
			if (m_bCanShoot)
			{
				
				if (m_shiftmodThis.ShiftState == PlayerShiftModel.State.Sword)
				{
					m_swordAttackThis.Fire ();
					m_bCanShoot = false;
				}

				if (m_shiftmodThis.ShiftState == PlayerShiftModel.State.Bow && m_bowAttackThis.m_bIsShooting)
				{
					m_bowAttackThis.Fire ();
				}

			} 

			if (m_bowAttackThis.m_bIsShooting)
			{
				m_bowAttackThis.Teleport ();	
			}
		}

		if (!m_bCanShoot && Input.GetAxis ("UseMode") < 0.1f)
		{
			StartCoroutine (DelayShot ());
		}
	}

	IEnumerator DelayShot()
	{
		yield return new WaitForSeconds (m_fShootDelay);
		m_bCanShoot = true;
	}
}
