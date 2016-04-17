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
	private bool m_bCanSlash = true;
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
		//Debug.Log(Input.GetButton("UseMode"));
		if ((Input.GetAxisRaw("UseMode")>0.5f||Input.GetButton("UseMode")) && m_bCanShoot) 
		{/*
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
			}*/
			if (m_bowAttackThis.m_bIsShooting)
			{
				m_bowAttackThis.Teleport ();
			} 

			else
			{
				m_bowAttackThis.Fire ();
			}
			m_bCanShoot = false;

		}

		if (!m_bCanShoot && Input.GetAxis ("UseMode") <= 0.0f)
		{
			m_bCanShoot = true;
		}

		if (Input.GetAxis ("LeftTrigger") > 0.5f && m_bCanSlash)
		{
			if(!m_swordAttackThis.m_bIsSlashing)
				m_swordAttackThis.Fire ();
			m_bCanSlash = false;
		}

		if (Input.GetAxis ("LeftTrigger") <= 0.1f && !m_bCanSlash)
		{
			m_bCanSlash = true;
		}
	}
}
