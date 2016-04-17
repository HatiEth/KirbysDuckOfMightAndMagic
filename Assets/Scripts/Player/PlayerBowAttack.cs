using UnityEngine;
using System.Collections;

public class PlayerBowAttack : ProjectileWeapon
{
	private GameObject m_goActiveArrow;
	private Rigidbody m_rigidActiveArrow;
	public bool m_bIsShooting { get; private set;}
	[SerializeField]
	private Rigidbody m_rigidPlayer;
	[SerializeField]
	private float m_fBowChargeTime = 0.5f;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		m_fDestroyDelay = 0.75f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_bIsShooting = false;
		if (m_goActiveArrow != null)
		{
			m_bIsShooting = true;
		} 
		else
		{
			m_goActiveArrow = null;
			m_rigidActiveArrow = null;
		}
	}

	public override bool Fire()
	{
		Debug.Log ("Fire Arrow");
		m_goActiveArrow = GameObject.Instantiate (m_goProjectilePrefab, transform.position, transform.rotation) as GameObject;
		m_rigidActiveArrow = m_goActiveArrow.GetComponent<Rigidbody> ();

		float angle = Vector3.Angle (Vector3.forward, transform.forward);
		if (transform.forward.x < 0)
			angle = -angle;
		Quaternion qRotation = Quaternion.Euler (new Vector3 (30.0f, 0.0f, -angle));
		m_goActiveArrow.transform.localRotation = qRotation;

		StartCoroutine (DelayedFire ());
		return true;
	}

	public void Teleport()
	{
		Debug.Log ("Teleport to Arrow");
		m_rigidPlayer.MovePosition (m_rigidActiveArrow.position);
		m_rigidPlayer.transform.position = m_rigidActiveArrow.position;
		DestroyProjectile (m_goActiveArrow);
		m_goActiveArrow = null;
		m_rigidActiveArrow = null;
		m_bIsShooting = false;
	}

	public IEnumerator DelayedFire()
	{
		yield return new WaitForSeconds (m_fBowChargeTime);
		m_rigidActiveArrow.AddForce ((transform.forward + m_v3ShotDirectionOffset) * m_fShotPower, ForceMode.Impulse);
		StartCoroutine (DelayDestroyProjectile(m_goActiveArrow));
	}
}
