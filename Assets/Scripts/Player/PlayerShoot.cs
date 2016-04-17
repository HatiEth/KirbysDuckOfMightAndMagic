using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	private ProjectileWeapon m_projectileThis;
	private PlayerSwordAttack m_swordAttackThis;
	private PlayerBowAttack m_bowAttackThis;
	[SerializeField]
	private PlayerShiftModel m_shiftmodPlayer;
	[SerializeField]
	private PlayerMovement m_movementPlayer;

	private bool m_bHasShoot = true;
	private bool m_bHasSlash = true;
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
		if (Input.GetButtonDown ("FireShield"))
		{
			m_shiftmodPlayer.NextState (PlayerShiftModel.State.Shield);
		} 

		else if (Input.GetButtonDown ("FireBow"))
		{
			m_shiftmodPlayer.NextState (PlayerShiftModel.State.Bow);

			if (m_bowAttackThis.m_bIsShooting)
			{
				m_bowAttackThis.Teleport ();
			} 
			else
			{
				m_bowAttackThis.Fire ();
			}
		}

		else if (Input.GetButtonDown ("FireSword"))
		{
			m_shiftmodPlayer.NextState (PlayerShiftModel.State.Sword);
			if (!m_swordAttackThis.m_bIsSlashing)
				m_swordAttackThis.Fire ();
			m_bHasSlash = false;
		} 

		else if (m_shiftmodPlayer.ShiftState == PlayerShiftModel.State.Sword && !m_swordAttackThis.m_bIsSlashing)
		{
			m_shiftmodPlayer.NextState (PlayerShiftModel.State.Default);
		}

		else if (m_shiftmodPlayer.ShiftState == PlayerShiftModel.State.Bow && !m_bowAttackThis.m_bIsShooting)
		{
			m_shiftmodPlayer.NextState (PlayerShiftModel.State.Default);
		}

		else if(Input.GetButtonUp("FireShield"))
		{
			m_shiftmodPlayer.NextState (PlayerShiftModel.State.Default);	
		}

		if (m_shiftmodPlayer.ShiftState != PlayerShiftModel.State.Default)
		{
			m_movementPlayer.blockMovement = true;
		} 
		else
		{
			m_movementPlayer.blockMovement = false;
		}

	}
}
